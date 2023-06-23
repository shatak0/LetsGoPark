using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsGoPark.WebSite.Models
{
    /// <summary>
    /// enum for Product/Game Category
    /// </summary>
    public enum ProductTypeEnum
    {
        one = 0,
        two = 1,
        three = 2,
    }

    /// <summary>
    /// Representing class enum for product/game category
    /// Grouping products/games together by category
    /// </summary>
    public static class ProductTypeEnumExtensions
    {
        /// <summary>
        /// enum value is displayed as a string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                ProductTypeEnum.one => "one",
                ProductTypeEnum.two => "two",
                ProductTypeEnum.three => "three",
                _ => throw new NotImplementedException(),
            };
        }
    }
}