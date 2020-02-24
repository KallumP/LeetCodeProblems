using System;
using System.Collections;

namespace Challenge1 {
    class Program {
        static void Main(string[] args) {

            Solution s = new Solution();

            Console.Write(s.DaysBetweenDates("2019-06-29", "2019-06-30"));
            Console.WriteLine(" 1");
            Console.Write(s.DaysBetweenDates("2020-01-15", "2019-12-31"));
            Console.WriteLine(" 15");
            Console.Write(s.DaysBetweenDates("2009-08-18", "2080-08-08"));
            Console.WriteLine(" 25923");
            Console.Write(s.DaysBetweenDates("2023-01-13", "2044-02-11"));
            Console.WriteLine(" 7699");
            Console.Write(s.DaysBetweenDates("2008-03-21", "2041-05-08"));
            Console.WriteLine(" 12101");
            Console.Write(s.DaysBetweenDates("1992-03-31", "2009-03-11"));
            Console.WriteLine(" 6189");
            Console.Write(s.DaysBetweenDates("2100-09-22", "1991-03-12"));
            Console.WriteLine(" 40006");
            Console.ReadLine();
        }
    }

    public class Solution {
        public int DaysBetweenDates(string date1, string date2) {

            int year1 = 0;
            int month1 = 0;
            int day1 = 0;

            year1 = Convert.ToInt16(date1.Substring(0, 4));
            month1 = Convert.ToInt16(date1.Substring(5, 2));
            day1 = Convert.ToInt16(date1.Substring(8, 2));


            int year2 = 0;
            int month2 = 0;
            int day2 = 0;

            year2 = Convert.ToInt16(date2.Substring(0, 4));
            month2 = Convert.ToInt16(date2.Substring(5, 2));
            day2 = Convert.ToInt16(date2.Substring(8, 2));


            #region Calculates which date is bigger
            bool date1Big = true;

            //checks to see if date 1 was bigger
            if (year1 > year2)
                date1Big = true;

            //checks to see if date 2 was bigger
            else if (year1 < year2)
                date1Big = false;

            //checks to see if the two dates had the same year
            else if (year1 == year2) {

                //checks to see if the date 1 was bigger
                if (month1 > month2)
                    date1Big = true;

                //checks to see if date 2 was bigger
                else if (month1 < month2)
                    date1Big = false;

                //checks to see if the two dates had the same month (as well as year)
                else if (month1 == month2) {

                    //checks to see if the date 1 was bigger
                    if (day1 > day2)
                        date1Big = true;

                    //checks to see if date 2 was bigger
                    else if (day1 < day2)
                        date1Big = false;

                    //checks to see if the two dates were the same
                    else if (day1 == day2) {


                    }
                }
            }

            Hashtable months = new Hashtable();
            months.Add("1", "31");
            months.Add("2", "28");
            months.Add("3", "31");
            months.Add("4", "30");
            months.Add("5", "31");
            months.Add("6", "30");
            months.Add("7", "31");
            months.Add("8", "31");
            months.Add("9", "30");
            months.Add("10", "31");
            months.Add("11", "30");
            months.Add("12", "31");
            #endregion

            int dayspassed = 0;

            #region Leap year exceptions (if the final year needs to account for a leap feb, or if the first year does not need a leap feb)
            bool addOn = false;
            bool takeOff = false;

            //if the final year was a leap year (and the month was after feb, that feb's leap day is not accounted for) we need to account for that missing day
            if (date1Big) {

                //checks to see if date 1's month was bigger than feb and if the date 1's year was a leap year and if the two years were different
                if (month1 > 2 && year1 % 4 == 0)

                    addOn = true;

            } else {

                //checks to see if date 1's month was bigger than feb and if the date 1's year was a leap year and if the two years were different
                if (month2 > 2 && year2 % 4 == 0)

                    addOn = true;
            }

            //if the starting small date starts after feb, and is a leap year, we must not add on the leap day for that year
            if (date1Big) {

                //checks to see if date 2 starts on a leap year, but after feb
                //if (month2 > 2 && year2 % 4 == 0 && (month2 > month1 || (month2 == month1 && day2 < day1)))
                if (month2 > 2 && year2 % 4 == 0)

                    takeOff = true;


            } else {

                //checks to see if date 1 starts on a leap year, but after feb
                //if (month1 > 2 && year1 % 4 == 0 && (month1 > month2 || (month1 == month2 && day1 < day2)))
                if (month1 > 2 && year1 % 4 == 0)

                    takeOff = true;
            }
            #endregion

            #region Calculate days difference
            //keeps looping until the days are the same
            while (day1 != day2) {

                //checks to see if date one was bigger
                if (date1Big) {

                    day2++;
                    dayspassed++;


                    //checks to see if the there are now too many days in the second date
                    if (day2 > Convert.ToInt32(months[month2.ToString()])) {

                        //checks to see if this is a leap febraury and the day is still 29 (bigger than the hashtable no of days in feb but not in a leap year)
                        if (month2 == 2 && year2 % 4 == 0 && day2 == 29) {

                        } else {

                            //registers that the next month was reached
                            month2++;

                            //resets the days
                            day2 = 1;

                            //checks to see if there are now too many months in the second date
                            if (month2 > 12) {

                                //registers that a new year was reached
                                year2++;

                                //resets the month
                                month2 = 1;
                            }
                        }
                    }

                } else {

                    day1++;
                    dayspassed++;


                    //checks to see if the there are now too many days in the second date
                    if (day1 > Convert.ToInt32(months[month1.ToString()])) {

                        //checks to see if this is a leap febraury and the day is still 29 (bigger than the hashtable no of days in feb but not in a leap year)
                        if (month2 == 2 && year2 % 4 == 0 && day2 == 29) {

                        } else {
                            //registers that the next month was reached
                            month1++;

                            //resets the days
                            day1 = 1;

                            //checks to see if there are now too many months in the second date
                            if (month1 > 12) {

                                //registers that a new year was reached
                                year1++;

                                //resets the month
                                month1 = 1;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Calculate months difference
            while (month1 != month2) {

                //checks to see if date one was bigger
                if (date1Big) {

                    month2++;
                    dayspassed += Convert.ToInt32(months[(month2 - 1).ToString()]);

                    //checks to see if the month was february
                    if (month2 - 1 == 2)

                        //checks to see if the year was leap (divisable by 4)
                        if (year2 % 4 == 0)

                            //adds on an extra day
                            dayspassed++;

                    //checks to see if there are now too many months in the second date
                    if (month2 > 12) {

                        //registers that a new year was reached
                        year2++;

                        //resets the month
                        month2 = 1;
                    }

                } else {

                    month1++;
                    dayspassed += Convert.ToInt32(months[(month1 - 1).ToString()]);

                    //checks to see if the month was february
                    if (month1 - 1 == 2)

                        //checks to see if the year was leap (divisable by 4)
                        if (year1 % 4 == 0)

                            //adds on an extra day
                            dayspassed++;

                    //checks to see if there are now too many months in the second date
                    if (month1 > 12) {

                        //registers that a new year was reached
                        year1++;

                        //resets the month
                        month1 = 1;
                    }
                }
            }
            #endregion

            //checks to see if we need to take off a day (because the first year does not need the leap day (started after the end of feb))
            if (takeOff && year1 != year2) {
                if (date1Big) {
                    if (year2 % 4 == 0)
                        dayspassed--;
                } else {
                    if (year1 % 4 == 0) {
                        dayspassed--;
                    }
                }
            }

            if (addOn && year1 != year2)
                dayspassed++;

            #region Calculate year difference
            //keeps looping until they are on the same year
            while (year1 != year2) {


                //checks to see if the first year is bigger than the second year
                if (year1 > year2) {

                    year2++;

                    //registers the days passed
                    if ((year2 - 1) % 4 == 0) dayspassed += 366;
                    else dayspassed += 365;

                } else {

                    year1++;

                    //registers the days passed
                    if ((year1 - 1) % 4 == 0) dayspassed += 366;
                    else dayspassed += 365;

                }
            }
            #endregion

            return dayspassed;
        }
    }
}
