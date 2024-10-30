using Candidate_BusinessObject;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool addCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.addCandidateProfile(candidateProfile);
       


        public bool deleteCandidateProfile(string candidateID) => CandidateProfileDAO.Instance.deleteCandidateProfile(candidateID);
       

        public CandidateProfile GetCandidateProfile(string id) => CandidateProfileDAO.Instance.GetCandidateProfile(id); 
       

        public List<CandidateProfile> GetCandidates() => CandidateProfileDAO.Instance.GetCandidates();  
       

        public bool updateCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.updateCandidateProfile(candidateProfile); 
        
    }
}