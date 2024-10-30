using Candidate_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
        private CandidateManagementContext dbContext;
        private static JobPostingDAO instance;

        public JobPosting GetJobPosting(string id)
        {
            return dbContext.JobPostings.SingleOrDefault(m => m.PostingId.Equals(id));
        }


        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        public JobPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public List<JobPosting> GetJobPostings()
        {
            return dbContext.JobPostings.ToList();  
        }

        public bool addJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting jobPosting1 = GetJobPosting(jobPosting.PostingId);
            if (jobPosting1 == null)
            {
                dbContext.JobPostings.Add(jobPosting);
                dbContext.SaveChanges();
                isSuccess = true;

            }
            return isSuccess;
        }

        public bool deleteJobPosting(string postingID)
        {
            bool isSuccess = false;
            JobPosting jobPosting = GetJobPosting(postingID);

            // Check if the job posting exists before attempting to delete it
            if (jobPosting != null)
            {
                bool hasDependencies = dbContext.CandidateProfiles.Any(candidate => candidate.PostingId == postingID);
                if (!hasDependencies)
                {
                    dbContext.JobPostings.Remove(jobPosting);
                    dbContext.SaveChanges();
                    isSuccess = true; // Mark as success since the deletion was performed
                } else
                {
                    isSuccess = false;
                }
               
            }

            return isSuccess; // Return whether the deletion was successful
        }


        public bool updateJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting jobPosting1 = GetJobPosting(jobPosting.PostingId);
            if (jobPosting1 != null)
            {
                dbContext.Entry<JobPosting>(jobPosting).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
                isSuccess = true;

            }
            return isSuccess;
        }
    }
}
