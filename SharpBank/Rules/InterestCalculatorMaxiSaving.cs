﻿using System;

namespace SharpBank.Rules
{
   /// <summary>
   /// Clase que implmenta la interfaz <see cref="IInterestCalculator"/>
   /// para las cuentas del tipo <see cref="AccountType.MaxiSavings"/>.
   /// </summary>
   public class InterestCalculatorMaxiSaving : IInterestCalculator
   {
      private const double PERCENTAGE_YEAR = 5;

      /// <summary>
      /// Calcula el interés generado del monto <paramref name="pAmount"/>
      /// desde la fecha <paramref name="pDate"/>.
      /// </summary>
      /// <param name="pAmount">Monto sobre el cuál se calcula el interés.</param>
      /// <param name="pDate">Fecha desde cuando se calcula el interés.</param>
      public double Calculate(double pAmount, DateTime pDate)
      {
         //var interestDay = Math.Round(PERCENTAGE_YEAR / 365, 3);
         //var countDayLast = (int)(DateTime.Now - pDate).TotalDays;
         //pAmount += (pAmount * (countDayLast * interestDay));

         pAmount += pAmount.DailyInterest(PERCENTAGE_YEAR, (int)(DateTime.Now - pDate).TotalDays);
         if (pAmount <= 1000)
            return pAmount * 0.02;
         else if (pAmount <= 2000)
            return 20 + (pAmount - 1000) * 0.05;
         else
            return 70 + (pAmount - 2000) * 0.1;
      }
   }
}
