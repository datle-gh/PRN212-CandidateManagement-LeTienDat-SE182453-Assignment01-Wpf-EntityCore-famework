using Candidate_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext dbcontext;
        private static CandidateProfileDAO instance;
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }

        }
        public CandidateProfileDAO()
        {
            dbcontext = new CandidateManagementContext();
        }

        public List<CandidateProfile> GetCandidates()
        {
            return dbcontext.CandidateProfiles.Include(u => u.Posting).ToList();
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return dbcontext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }


        public bool addCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate == null)
            {
                dbcontext.CandidateProfiles.Add(candidateProfile);
                dbcontext.SaveChanges();
                isSuccess = true;

            }
            return isSuccess;
        }

        public bool deleteCandidateProfile(string candidateID) 
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateID);
            if (candidate != null)
            {
                dbcontext.CandidateProfiles.Remove(candidate);
                dbcontext.SaveChanges();
                isSuccess = true;

            }
            return isSuccess;
        }

        public bool updateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate != null)
            {
                dbcontext.Entry<CandidateProfile>(candidateProfile).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbcontext.SaveChanges();
                isSuccess = true;

            }
            return isSuccess;
        }
    }
}
