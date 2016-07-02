using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Helpers
{
    public static class EnumHelper
    {
        public static readonly List<string> Genders = new List<string> 
        {
            "female", "male"
        };
        public static readonly List<string> Genders_zh = new List<string> 
        {
            "女", "男"
        };
        public static readonly List<string> EthnicGroups = new List<string> 
        {
            "White", "Black", "Asian",  "Native American", "Hispanic"
        };
        public static readonly List<string> EthnicGroups_zh = new List<string>
        {
            "白人", "非裔", "亚裔", "美洲原住民", "拉丁裔"
        };
        public static readonly List<string> ExerciseLevels = new List<string> 
        {
            "Sedentary", "Moderate", "Vigorous"
        };
        public static readonly List<string> ExerciseLevels_zh = new List<string>
        {
            "久坐不动",  "适度运动", "强度运动"
        };
        public static readonly List<string> MaritalStatus = new List<string> 
        {
            "Married", "Divorced", "Single", "Widow"
        };
        public static readonly List<string> MaritalStatus_zh = new List<string> 
        {
            "结婚", "离婚", "单身", "丧偶"
        };
    }
}