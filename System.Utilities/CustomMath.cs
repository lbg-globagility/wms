using System;

namespace WarehouseManagementSystem.Utilities
{
    public static class CustomMath
    {
        /// <summary>
        /// Perform a commercial rounding away from zero.
        ///
        /// ex:
        /// 1.284 -> 1.28
        /// 1.285 -> 1.29
        /// 1.286 -> 1.29
        /// </summary>
        /// <param name="value"></param>
        /// <param name="places"></param>
        /// <returns></returns>
        public static decimal CommercialRound(decimal value, int places = 2)
        {
            return Math.Round(value, places, MidpointRounding.AwayFromZero);
        }

        public static decimal CommercialRound(decimal? value, int places = 2)
        {
            if (value == null) return 0M;

            return CommercialRound(value.Value, places);
        }

        public static decimal CommercialRound(double value, int places = 2)
        {
            return CommercialRound((decimal)value, places);
        }
    }
}