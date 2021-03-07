using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using RDotNet;
using Accord.Statistics;
using Accord.IO;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace TSAnalyzer.Controllers
{
    [EnableCors("RonysPolicy")]  
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : RestfulControllerBase<Parameter>
    {


        private readonly IRepository<Parameter> _repository;


        public ParameterController(IRepository<Parameter> repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("get")]
        public ActionResult<double> get()
        {

            return 1;
        }


        [HttpPost("accordCalculation")]
        public ActionResult<Dictionary<string, double>> accordCalculation([FromBody] object data)
        {
           
            List<TSData> listEntries = JsonConvert.DeserializeObject<List<TSData>>(data.ToString());

            //select just the Time series values
            List<Double> listValues = listEntries.Select(x => x.Value).ToList();


            double[] values = listValues.ToArray();

            //proceed to calculations

            double sd = Measures.StandardDeviation(values);

            double mean = Measures.Mean(values);

            double mode = Measures.Mode(values);

            double median = Measures.Median(values);

            double skewness = Measures.Skewness(values);

            double kurtosis = Measures.Kurtosis(values);

            double variance = Measures.Variance(values);

            double lowerQuartile = Measures.LowerQuartile(values);

            double upperQuartile = Measures.UpperQuartile(values);


            //return result as dictionary


            Dictionary<string, double> resultDict = new Dictionary<string, double>()
            {
                {"Mean",mean},
                {"Mode",mode},
                {"Median",median},
                {"Standard Deviation",sd},
                {"Variance",variance},
                {"Skewness",skewness},
                {"Kurtosis",kurtosis},
                {"Lower Quartile",lowerQuartile},
                {"Upper Quartile",upperQuartile},



            };


            return resultDict;
        }


        // POST api/values
        [HttpPost("getMeanSDandVarFromCSV")]
        public ActionResult<List<double>> getMeanSDandVarFromCSV([FromBody] string csvFilePath)
        {

            CsvReader reader = new CsvReader(csvFilePath,true);

            //double sd = Measures.StandardDeviation(reader);


            List<double> result = new List<double>();



            return result;
        }

        // POST api/values
        [HttpPost("getMeanSDandVar")]
        public ActionResult<List<double>> getMeanSDandVar([FromBody] List<double> dataValues)
        {

            List<double> result = new List<double>();
            double mean;
            double sd;
            double variance;

            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();

            try
            {
                //engine.Evaluate("install-packages(stats)");


    

                //CalculateMean
                NumericVector values = engine.CreateNumericVector(dataValues);
                engine.SetSymbol("values", values);
                mean = engine.Evaluate("mean(values)").AsNumeric().First();
                //sd = engine.Evaluate("sd(values)").AsNumeric().First();
                //variance = engine.Evaluate("var(values)").AsNumeric().First();


                

            }
            catch (Exception e)
            {
                mean = 0;
                sd = 0;
                variance = 0;


            }

            engine.Dispose();
            result.Add(mean);
            //result.Add(sd);
            //result.Add(variance);

            Parameter param = new Parameter();
            param.AnalysisId =1;
           param.Description = "test save DB";
                param.Name = "average";
            param.Value =mean;


            _repository.Add(param);



            return result;





        }

    }
}
