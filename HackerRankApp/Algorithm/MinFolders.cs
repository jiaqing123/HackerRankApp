namespace HackerRankApp.Algorithm
{
    public static class MinFolders
    {
        public static int Run(int cssFiles, int jsFiles, int readMeFiles, int capacity)
        {
            // cssFiles, jsFiles. if none other, 1. if there are jsFiles+1/cssFiles+1

            // readMeFiles: 0,1

            // if readMeFiles[0-1], cssFiles:[0-2], jsFiles: [0-2]

            // capacity: readMeFiles+cssFiles+jsFiles

            var halfCapacity = capacity / 2;
            var isEvenCapacity = capacity % 2 == 0;

            if (halfCapacity == 0)
            {
                return cssFiles + jsFiles + readMeFiles;
            }

            if (readMeFiles == 0)
            {
                var larger = Math.Max(cssFiles, jsFiles);
                var smaller = Math.Min(cssFiles, jsFiles);

                if (larger == smaller)
                {
                    return (int)Math.Ceiling((larger + smaller) / (double)capacity);
                }
                else
                {
                    if (isEvenCapacity)
                    {
                        var common = (int)Math.Ceiling((smaller + smaller) / (double)capacity);

                        var largerLeft = larger - halfCapacity * common;

                        var isLastCommonFull = halfCapacity * common == smaller;
                        if (!isLastCommonFull)
                        {
                            largerLeft -= 1;
                        }

                        if (largerLeft > 0)
                        {
                            return common + largerLeft / 1;
                        }
                        else
                        {
                            return common;
                        }
                    }
                    else
                    {
                        var common = (int)Math.Ceiling((smaller + smaller) / (double)capacity);

                        var largerLeft = larger - (halfCapacity + 1) * common;

                        var isLastCommonFull = halfCapacity * common == smaller;
                        if (!isLastCommonFull)
                        {
                            largerLeft -= 1;
                        }

                        if (largerLeft > 0)
                        {
                            return common + largerLeft / 1;
                        }
                        else
                        {
                            return common;
                        }
                    }
                }
            }
            else
            {
                var readmeFolders = readMeFiles;

                var larger = Math.Max(cssFiles, jsFiles);
                var smaller = Math.Min(cssFiles, jsFiles);

                if (capacity == 2)
                {
                    var diff = larger - smaller;

                    if (diff >= readMeFiles)
                    {
                        larger -= readMeFiles;
                    }
                    else
                    {
                        var moving = (readMeFiles - diff) / 2 + diff;

                        larger -= moving;
                        smaller -= readMeFiles - moving;

                        var tmpL = Math.Max(larger, smaller);
                        var tmpS = Math.Min(larger, smaller);

                        larger = tmpL;
                        smaller = tmpS;
                    }

                    if (larger == smaller)
                    {
                        return readmeFolders + (int)Math.Ceiling((larger + smaller) / (double)capacity);
                    }
                    else
                    {
                        if (isEvenCapacity)
                        {
                            var common = (int)Math.Ceiling((smaller + smaller) / (double)capacity);

                            var largerLeft = larger - halfCapacity * common;

                            var isLastCommonFull = halfCapacity * common == smaller;
                            if (!isLastCommonFull)
                            {
                                largerLeft -= 1;
                            }

                            if (largerLeft > 0)
                            {
                                return readmeFolders + common + largerLeft / 1;
                            }
                            else
                            {
                                return readmeFolders + common;
                            }
                        }
                        else
                        {
                            var common = (int)Math.Ceiling((smaller + smaller) / (double)capacity);

                            var largerLeft = larger - (halfCapacity + 1) * common;

                            var isLastCommonFull = halfCapacity * common == smaller;
                            if (!isLastCommonFull)
                            {
                                largerLeft -= 1;
                            }

                            if (largerLeft > 0)
                            {
                                return readmeFolders + common + largerLeft / 1;
                            }
                            else
                            {
                                return readmeFolders + common;
                            }
                        }
                    }
                }
                else
                {
                    larger -= readMeFiles;
                    smaller -= readMeFiles;

                    if (smaller <= 0)
                    {
                        if (larger > 0)
                        {
                            return readMeFiles + larger;
                        }
                        else
                        {
                            return readMeFiles;
                        }
                    }

                    if (larger == smaller)
                    {
                        return readMeFiles + (int)Math.Ceiling((larger + smaller) / (double)capacity);
                    }

                    if (isEvenCapacity)
                    {
                        var common = (int)Math.Ceiling((smaller + smaller) / (double)capacity);

                        var largerLeft = larger - halfCapacity * common;

                        var isLastCommonFull = halfCapacity * common == smaller;
                        if (!isLastCommonFull)
                        {
                            largerLeft -= 1;
                        }

                        if (largerLeft > 0)
                        {
                            return readmeFolders + common + largerLeft / 1;
                        }
                        else
                        {
                            return readmeFolders + common;
                        }
                    }
                    else
                    {
                        var common = (int)Math.Ceiling((smaller + smaller) / (double)capacity);

                        var largerLeft = larger - (halfCapacity + 1) * common;

                        var isLastCommonFull = halfCapacity * common == smaller;
                        if (!isLastCommonFull)
                        {
                            largerLeft -= 1;
                        }

                        if (largerLeft > 0)
                        {
                            return readmeFolders + common + largerLeft / 1;
                        }
                        else
                        {
                            return readmeFolders + common;
                        }
                    }
                }
            }
        }
    }
}
