using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHUPA_ASSIGNEMENT_1.BAL
{
    public class TimeConversion
    {
        public static DateTime GetLocalProgramTime(DateTime Time)
        {
            TimeZoneInfo estTimezone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime LocalTime = TimeZoneInfo.ConvertTime(Time, estTimezone, TimeZoneInfo.Local);
            return LocalTime;
        }

        public static IEnumerable<Program> UpdateProgramTimings(IEnumerable<Program> program_records)
        {
            foreach (Program p_record in program_records)
            {
                p_record.StartTime = GetLocalProgramTime(p_record.StartTime);
                p_record.EndTime = GetLocalProgramTime(p_record.EndTime);
            }
            return program_records;
        }
    }
}