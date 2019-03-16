using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalsApplicationMark1.Common
{
    public class Category
    {
        public enum EnumCategory
        {
            Professional, Jujitsu, Language, Hobby, Family, Faith, Health
        }

        public enum EnumSubCategory
        {
            Development, PMP, Testing, Leadership,
            BJJ, Budoshin, Aikido, KravMaga,
            Portuguese, Russian, Spanish, French, MakerOrDiy,
            Marriage, Bella, Whisper,
            Praying, Reading, Worshipping, Contemplating, Serving, Giving,
            Sleep, Weight, Exercise, Nutrition, Mindfulness, Scratch
        }

        public enum NanoCategory
        {
            None, CSharp, ASPNETCORE, Postgresql, MSTest, NUnit, XUnit, Html, Css, Bootstrap, JavaScript, Angular, TypeScript, Postman,
        }
    }   
}
