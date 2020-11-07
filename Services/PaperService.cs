using Bursa.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bursa.Services
{
    public class PaperService
    {
        private ApplicationContext db;
        public PaperService(ApplicationContext context)
        {
            db = context;
        }
        public string GetPapers(int page, int rows, DateTime from, DateTime to)
        {
            string result = string.Empty;
            IList<Paper> lstPapers = null;
            IList<BursaType> lstBursaTypes = null;
            IList<PaperType> lstPaperTypes = null;
            int totalRows = 0;

            try
            { 
                totalRows = db.Papers.Count();
                //if (page > 0 && rows > 0)
                //TODO in CLient
                //if(false)
                //{
                //    lstPapers = (from paper in db.Papers.Include(pt => pt.PaperTypeValue).Skip((page - 1) * rows).Take(rows)
                //                 select paper).ToList();
                //}
                //else
                //{
                    lstPapers = (from paper in db.Papers.Include(pt => pt.PaperTypeValue)
                                 where paper.DateIssue >= @from && paper.DateIssue <= @to
                                 select paper).Skip((page - 1) * rows).Take(rows).ToList();
                //}

                lstBursaTypes = (from bt in db.BursaTypeList
                       select bt).ToList();
                lstPaperTypes = (from pt in db.PaperTypeList
                                 select pt).ToList();
 

                var objects = new { PapersList = lstPapers, BursaTypeList = lstBursaTypes, PaperTypeList = lstPaperTypes, TotalPapers = totalRows };
                result = JsonSerializer.Serialize(objects);
                return result;
            }
            catch (Exception ex)
            {
                //TODO
                throw (ex);

            }

        }

        public string GetPaperById(int id)
        {
            string result = string.Empty;
 
            int errorCode = 0;
            Paper paper = null;

            try
            {
                paper = (from p in db.Papers.Include(pt => pt.PaperTypeValue)
                                 where p.PaperId == @id
                                 select p).First();
             }
            catch (Exception ex)
            {
                errorCode = -1;
            }
            finally
            {
                var objects = new { GetPaperById = paper, ErrorCode = errorCode };
                result = JsonSerializer.Serialize(objects);
            }
            return result;
        }
       public string SearchPapersByName(string name)
        {
            string result = string.Empty;
 
            int errorCode = 0;
            IList<Paper> lstPapers = null;

            try
            {
                string pattern =  string.Format("%{0}%",name) ;
                lstPapers = (from p in db.Papers  where EF.Functions.Like(p.PaperName, pattern)
                select p).ToList();
            }
            catch (Exception ex)
            {
                errorCode = -1;
            }
            finally
            {
                var objects = new { SearchPapersByName = lstPapers, ErrorCode = errorCode };
                result = JsonSerializer.Serialize(objects);
            }
            return result;
        }



    }
}
