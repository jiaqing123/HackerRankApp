namespace HackerRankApp.Problems;

/// <summary>
/// https://www.hackerrank.com/challenges/almost-sorted/problem?isFullScreen=true
/// </summary>
public static class AlmostSorted
{
	private const string Yes = "yes";
	private const string No = "no";

	private record NumberWindow(List<int> list)
	{
		public int PreviousIndex { get => CurrentIndex > 0 ? CurrentIndex - 1 : -1; }
		public int CurrentIndex { get; set; } = -1;
		public int StartIndex { get; set; } = -1;
		public int EndIndex { get; set; } = -1;
		public int Previous { get => PreviousIndex >= 0 ? list[PreviousIndex] : -1; }
		public int Current { get => CurrentIndex >= 0 ? list[CurrentIndex] : -1; }
		public int Start { get => StartIndex >= 0 ? list[StartIndex] : -1; }
		public int End { get => EndIndex >= 0 ? list[EndIndex] : -1; }
		public bool IsCurrentLast { get => CurrentIndex >= list.Count - 1; }
		public int Size { get => StartIndex >= 0 && EndIndex >= 0 ? EndIndex - StartIndex + 1 : -1; }
	}

	private interface ISorter
	{
		public bool Actioned { get; }
		public bool Disordered { get; }
		List<string> GetResult();
		void Process(int index);
	}

	private class Swapper(List<int> list) : ISorter
	{
		public bool Actioned { get => _actioned; }

		public bool Disordered { get => _disordered; }

		private readonly NumberWindow _window = new(list);

		private bool _actioned = false;
		private bool _disordered = false;

		public void Process(int index)
		{
			if (_disordered) return;

			_window.CurrentIndex = index;

			if (_actioned)
			{
				if (IsDecreased())
				{
					_disordered = true;
				}
				return;
			}

			if (_window.StartIndex == -1)
			{
				_window.StartIndex = _window.CurrentIndex;
				return;
			}

			if (_window.EndIndex == -1)
			{
				if (_window.Current >= _window.Start)
				{
					_window.StartIndex = _window.CurrentIndex;
				}
				else
				{
					_window.EndIndex = _window.CurrentIndex;

					if (_window.IsCurrentLast)
					{
						_actioned = true;
					}

					if (_window.StartIndex > 0 && list[_window.StartIndex - 1] > _window.Current)
					{
						_disordered = true;
					}
				}
				return;
			}

			// Start End is swappable
			if (_window.Current >= _window.Start)
			{
				_actioned = true;

				if (_window.Size > 2)
				{
					_disordered = true;
				}
			}
			else if (_window.Current >= _window.End)
			{
				_window.EndIndex = _window.CurrentIndex;

				if (_window.IsCurrentLast)
				{
					_disordered = true;
				}
			}
			else if (_window.Current <= list[_window.StartIndex + 1])
			{
				_window.EndIndex = _window.CurrentIndex;
				_actioned = true;
			}
			else
			{
				_disordered = true;
			}
		}

		public List<string> GetResult()
		{
			if (_disordered)
			{
				return [No];
			}

			if (_actioned)
			{
				return [Yes, Swapped(_window.StartIndex + 1, _window.EndIndex + 1)];
			}

			return [Yes];
		}

		private bool IsDecreased()
		{
			// after the swap range
			if (_window.CurrentIndex == _window.EndIndex + 1)
			{
				// smaller than the range
				if (_window.Current < _window.Start)
				{
					return true;
				}
			}
			// smaller than previous
			else if (_window.Current < _window.Previous)
			{
				return true;
			}
			return false;
		}

		private static string Swapped(int start, int end) => $"swap {start} {end}";
	}

	private class Reverser(List<int> list) : ISorter
	{
		public bool Actioned { get => _actioned; }

		public bool Disordered { get => _disordered; }

		private readonly NumberWindow _window = new(list);

		private bool _actioned = false;
		private bool _disordered = false;

		public void Process(int index)
		{
			if (_disordered) return;

			_window.CurrentIndex = index;

			if (_actioned)
			{
				if (_window.CurrentIndex == _window.EndIndex + 1)
				{
					if (_window.Current < _window.Start)
					{
						_disordered = true;
					}
				}
				else if (_window.Current < _window.Previous)
				{
					_disordered = true;
				}
				return;
			}

			if (_window.StartIndex == -1)
			{
				_window.StartIndex = index;
				return;
			}

			if (_window.EndIndex == -1)
			{
				if (_window.Current >= _window.Start)
				{
					_window.StartIndex = _window.CurrentIndex;
				}
				else
				{
					_window.EndIndex = _window.CurrentIndex;

					if (_window.IsCurrentLast)
					{
						_actioned = true;
					}

					if (_window.StartIndex > 0 && list[_window.StartIndex - 1] > _window.Current)
					{
						_disordered = true;
					}
				}
				return;
			}

			if (_window.Current <= _window.Previous)
			{
				_window.EndIndex = _window.CurrentIndex;

				if (_window.IsCurrentLast)
				{
					_actioned = true;
				}

				if (_window.StartIndex > 0 && list[_window.StartIndex - 1] > _window.Current)
				{
					_disordered = true;
				}
			}
			else if (_window.Current >= _window.Start)
			{
				_actioned = true;
			}
			else
			{
				_disordered = true;
			}


			if (_window.Current >= _window.Start)
			{
				if (_window.EndIndex == -1)
				{
					_window.StartIndex = _window.CurrentIndex;
				}
				else
				{
					_actioned = true;
				}

				return;
			}
		}

		public List<string> GetResult()
		{
			if (_disordered)
			{
				return [No];
			}

			if (_actioned)
			{
				return [Yes, Reversed(_window.StartIndex + 1, _window.EndIndex + 1)];
			}

			return [Yes];

		}

		private static string Reversed(int start, int end) => $"reverse {start} {end}";
	}

	public static List<string> Run(List<int> list)
	{
		if (list.Count == 0) return [No];

		var sorters = new List<ISorter>()
		{
			new Swapper(list),
			new Reverser(list)
		};

		for (int i = 0; i < list.Count; i++)
		{
			sorters.ForEach(e => e.Process(i));

			if (sorters.All(e => e.Disordered)) break;
		}

		foreach (var sorter in sorters)
		{
			if (sorter.Disordered) continue;

			return sorter.GetResult();
		}

		return sorters.First().GetResult();
	}
}
