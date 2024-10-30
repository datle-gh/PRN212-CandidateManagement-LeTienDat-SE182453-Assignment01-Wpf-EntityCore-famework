using Candidate_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class HRAccountDAO
    {
        private CandidateManagementContext dbContext;
        private static HRAccountDAO instance = null;
        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public HRAccountDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public Hraccount GetHraccountByEmail(String email)
        {
            return dbContext.Hraccounts.SingleOrDefault(n => n.Email.Equals(email));
        }

        public List<Hraccount> GetHraccounts() {
            return dbContext.Hraccounts.ToList();
        }
    }
}
