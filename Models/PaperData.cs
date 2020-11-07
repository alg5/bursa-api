using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bursa.Models
{
    public class PaperData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new ApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationContext>>()))
            {
                // Look for any papers.
                if (db.Papers.Any())
                {
                    return;   // DB has been created
                }
                Random random = new Random();
                Random randomDate = new Random();
                DateTime endDate = DateTime.Today;
                DateTime startDate = endDate.AddYears(-3);
                BursaType btIsrael = new BursaType { Name = "Israel" };
                BursaType btUsa = new BursaType { Name = "Usa" };
                BursaType btEurope = new BursaType { Name = "Europe" };
                 db.BursaTypeList.AddRange(btIsrael, btUsa, btEurope);

                PaperType ptStock = new PaperType { Name = "איגרות חוב", Bursa = btIsrael };
                PaperType ptBond = new PaperType { Name = "מניות", Bursa = btIsrael };
                PaperType ptMaof = new PaperType { Name = "מעו\"ף", Bursa = btIsrael };
                PaperType ptFund = new PaperType { Name = "קרנות", Bursa = btIsrael };
                PaperType ptEtf = new PaperType { Name = " קרנות סל", Bursa = btIsrael };
                PaperType ptIssue = new PaperType { Name = "הנפקות", Bursa = btIsrael };
                PaperType ptStockUsa = new PaperType { Name = " מניות ארה\"ב", Bursa = btUsa };
                PaperType ptUsaOption = new PaperType { Name = " אופציות ארה\"ב", Bursa = btUsa };
                PaperType ptStocEurope = new PaperType { Name = "מניות אירוֹפה", Bursa = btEurope };

                db.PaperTypeList.AddRange(
                    ptStock,
                    ptBond,
                    ptMaof,
                    ptFund,
                    ptEtf,
                    ptIssue,
                    ptStockUsa,
                    ptUsaOption,
                    ptStocEurope
                    );
                db.Papers.AddRange(
                    new Paper
                    {

                        PaperName = "לאומי",
                        //paperBursa = b1,
                        PaperTypeValue = ptStock,
                        LastDeal = "13:55",
                        LastRate = 1684.4,
                        LastRatePercent = 2.99,
                        Amount = 1811,
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                        
                    },
                    new Paper
                    {

                        PaperName = "טבע",
                        //paperBursa = b1,
                        PaperTypeValue = ptStock,
                        LastDeal = "14:25",
                        LastRate = 3185,
                        LastRatePercent = -0.22,
                        Amount = 740,
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                        
                    },
                    new Paper
                    {

                        PaperName = "טבע1",
                        PaperTypeValue = ptMaof,
                        LastDeal = "12:35",
                        LastRate = 0,
                        LastRatePercent = -0.26,
                        Amount = 140,
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                        
                    },
                    new Paper
                    {

                        PaperName = "טבע2",
                        PaperTypeValue = ptMaof,
                        LastDeal = "22:25",
                        LastRate = 123,
                        LastRatePercent = 12.6,
                        Amount = 10040,
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                    },
                    new Paper
                    {

                        PaperName = "טבע3",
                        PaperTypeValue = ptFund,
                        LastDeal = "22:25",
                        LastRate = 123,
                        LastRatePercent = 12.6,
                        Amount = 10040,
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                        
                    },
                   new Paper
                   {

                       PaperName = "טבע4",
                       PaperTypeValue = ptFund,
                       LastDeal = "02:25",
                       LastRate = 456,
                       LastRatePercent = 42.6,
                       Amount = 70040,
                       RateBuy = random.NextDouble(0.1, 1000),
                       RateSell = random.NextDouble(0.1, 1000),
                       DateIssue = random.NextDate(startDate),
                       
                   },
                  new Paper
                  {

                      PaperName = "טבע5",
                      PaperTypeValue = ptUsaOption,
                      LastDeal = "02:25",
                      LastRate = 456,
                      LastRatePercent = 42.6,
                      Amount = 70040,
                      RateBuy = random.NextDouble(0.1, 1000),
                      RateSell = random.NextDouble(0.1, 1000),
                      DateIssue = random.NextDate(startDate),
                  },
                    new Paper
                    {
                        PaperName = "טבע6",
                        PaperTypeValue = ptUsaOption,
                        LastDeal = "02:25",
                        LastRate = random.NextDouble(0.1, 1000),
                        LastRatePercent = random.NextDouble(-100, 100),
                        Amount = (int)random.NextDouble(0, 10000),
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                    }
                    ,
                    new Paper
                    {
                        PaperName = "מקרוסופט",
                        PaperTypeValue = ptStockUsa,
                        LastDeal = "02:25",
                        LastRate = random.NextDouble(0.1, 1000),
                        LastRatePercent = random.NextDouble(-100, 100),
                        Amount = (int)random.NextDouble(0, 10000),
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                    }
                   ,
                    new Paper
                    {
                        PaperName = "1מקרוסופט",
                        PaperTypeValue = ptStockUsa,
                        LastDeal = "02:25",
                        LastRate = random.NextDouble(0.1, 1000),
                        LastRatePercent = random.NextDouble(-100, 100),
                        Amount = (int)random.NextDouble(0, 10000),
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                    }
                   ,
                    new Paper
                    {
                        PaperName = "2מקרוסופט",
                        PaperTypeValue = ptStockUsa,
                        LastDeal = "02:25",
                        LastRate = random.NextDouble(0.1, 1000),
                        LastRatePercent = random.NextDouble(-100, 100),
                        Amount = (int)random.NextDouble(0, 10000),
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                    }
                   ,
                    new Paper
                    {
                        PaperName = "אפל",
                        PaperTypeValue = ptStockUsa,
                        LastDeal = "02:25",
                        LastRate = random.NextDouble(0.1, 1000),
                        LastRatePercent = random.NextDouble(-100, 100),
                        Amount = (int)random.NextDouble(0, 10000),
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                    }
                                      ,
                    new Paper
                    {
                        PaperName = "אפל2",
                        PaperTypeValue = ptStockUsa,
                        LastDeal = "02:25",
                        LastRate = random.NextDouble(0.1, 1000),
                        LastRatePercent = random.NextDouble(-100, 100),
                        Amount = (int)random.NextDouble(0, 10000),
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                    }
                                     ,
                    new Paper
                    {
                        PaperName = "אמזון",
                        PaperTypeValue = ptStockUsa,
                        LastDeal = "02:25",
                        LastRate = random.NextDouble(0.1, 1000),
                        LastRatePercent = random.NextDouble(-100, 100),
                        Amount = (int)random.NextDouble(0, 10000),
                        RateBuy = random.NextDouble(0.1, 1000),
                        RateSell = random.NextDouble(0.1, 1000),
                        DateIssue = random.NextDate(startDate),
                    }
                    ); 
                db.SaveChanges();
            }
        }
          
    }
    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            //random(0, 1) * 2 - 1).
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
        public static DateTime NextDate(
            this Random random,
            DateTime startDate)
        {
            DateTime endDate = DateTime.Today;
            
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
            return startDate + newSpan;

        }

    }
}
