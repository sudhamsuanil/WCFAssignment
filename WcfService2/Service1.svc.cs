using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService2.Model;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static List<JobOpenings> jobOpen = new List<JobOpenings>();
      
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Service1()
        {
            jobOpen.Add(new JobOpenings { roleName = "Architect", experience = "10 years", roleDescription = "Responsible as solution architect" });
            jobOpen.Add(new JobOpenings { roleName = "Developer", experience = "5 years", roleDescription = ".net developer" });
            jobOpen.Add(new JobOpenings { roleName = "Tester", experience = "3 years", roleDescription = "Selenium testing" });

        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<JobOpenings> OpeningJobs()
        {
           
            return jobOpen;
        }

        public List<JobOpenings> OpeningJobsByRole(string roleName)
        {
            return jobOpen.Where(x => x.roleName.ToLower() == roleName.ToLower()).ToList();
        }
    }
}
