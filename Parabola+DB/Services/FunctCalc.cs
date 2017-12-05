using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParabolaDB.Models;

namespace ParabolaDB.Services
{
    public class FunctCalc
    {
        public static List<PointXY> getPoints()
        {
            return Points;
        }
        
        public static List<PointXY> Points = new List<PointXY>{ };

        private static double CalcY(double a, double b, double c, double x)
        {
            return x * x * a + x * b + c;
        }

        private static int TakeId(Param par, ParabolaContext db)
        {
            Param temp = db.Params.FirstOrDefault(param => (param.CoefficientA == par.CoefficientA)&&
                                                           (param.CoefficientB == par.CoefficientB)&&
                                                           (param.CoefficientC == par.CoefficientC)&&
                                                           (param.Step == par.Step)&&
                                                           (param.RangeFrom == par.RangeFrom)&&
                                                           (param.RangeTo == par.RangeTo));
            if (temp == null)
            {
                return 0;
            }
            else
            {
                return temp.ParamId;
            }
                     
        }

        private static List<PointXY> TakeSolutionFromDB(int param_id, ParabolaContext db)
        {
            List<CacheData> tempCache = db.CacheDatas.Where(cache => cache.ParamId == param_id).ToList();
            List<PointXY> tempPoint = new List<PointXY> { };
            foreach(CacheData cache in tempCache){
                tempPoint.Add(new PointXY { x = cache.PointX, y = cache.PointY});
            }

            return tempPoint;
        }

        private static void AddSolutionInDB(Param par, ParabolaContext db)
        { 
            db.Params.Add(par);    
            db.SaveChanges();                   // For increment ParamId
            foreach (PointXY p in Points)
            {
                CacheData temp = new CacheData();
                temp.ParamId = par.ParamId;
                temp.PointX = p.x;
                temp.PointY = p.y;
                db.CacheDatas.Add(temp);          
            }

            db.SaveChanges();
        }

        public static void GeneratePoints(Param par, ParabolaContext db)
        {
            int param_id =TakeId(par, db);
            if (param_id > 0) {
                Points = TakeSolutionFromDB(param_id, db);
            }
            else
            {
                Points.Clear();
                int count = 0;
                double i = par.RangeFrom;
                double step = par.Step;
                if (step > 0f) { 
                    while ((i <= par.RangeTo)  && (count < 100000))
                    {
                        Points.Add(new PointXY { x = i, y = CalcY(par.CoefficientA, par.CoefficientB, par.CoefficientC, i) });
                        i += step;
                        count++;
                    }
                
                    AddSolutionInDB(par, db);
                }

            }
        }

        
    }
}