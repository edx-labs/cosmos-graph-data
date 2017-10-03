using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechRecruiting.Models;

namespace TechRecruiting.DataGeneration
{
    public class SamplePortraitDataCollection : Collection<Portrait>
    {
        public SamplePortraitDataCollection()
            : base(
                new List<Portrait>
                {
                    new Portrait { Id = "recruiter-freya-portrait", ImageUrl = "media/recruiter-freya.jpg", ImageAuthorName = "Michael Dam", ImageSourceId = "mEZ3PoFGs_k", ImageAuthorId = "michaeldam" },
                    new Portrait { Id = "recruiter-daniel-portrait", ImageUrl = "media/recruiter-daniel.jpg", ImageAuthorName = "Tamarcus Brown", ImageSourceId = "29pFbI_D1Sc", ImageAuthorId = "tamarcusbrown" },
                    new Portrait { Id = "recruiter-susan-portrait", ImageUrl = "media/recruiter-susan.jpg", ImageAuthorName = "Cherry Laithang", ImageSourceId = "zEkuDYj6dq8", ImageAuthorId = "laicho" },
                    new Portrait { Id = "candidate-lev-portrait", ImageUrl = "media/candidate-lev.jpg", ImageAuthorName = "JodyHongFilms", ImageSourceId = "Y7vHfwv4-MQ", ImageAuthorId = "jhong8" },
                    new Portrait { Id = "candidate-ilya-portrait", ImageUrl = "media/candidate-ilya.jpg", ImageAuthorName = "Caique Silva", ImageSourceId = "KJE--xk4AWE", ImageAuthorId = "caiqueportraits" },
                    new Portrait { Id = "candidate-erin-portrait", ImageUrl = "media/candidate-erin.jpg", ImageAuthorName = "Joe Gardner", ImageSourceId = "pAs4IM6OGWI", ImageAuthorId = "josephgardnerphotography" },
                    new Portrait { Id = "candidate-ari-portrait", ImageUrl = "media/candidate-ari.jpg", ImageAuthorName = "Aravind Kumar", ImageSourceId = "xqkCgI1oSlg", ImageAuthorId = "aravind91" },
                    new Portrait { Id = "candidate-brittany-portrait", ImageUrl = "media/candidate-brittany.jpg", ImageAuthorName = "Eye for Ebony", ImageSourceId = "OeXcIHFwtsM", ImageAuthorId = "eyeforebony" },
                    new Portrait { Id = "candidate-greg-portrait", ImageUrl = "media/candidate-greg.jpg", ImageAuthorName = "rawpixel.com", ImageSourceId = "PG3NsaGpY3s", ImageAuthorId = "rawpixel" },
                    new Portrait { Id = "candidate-marc-portrait", ImageUrl = "media/candidate-marc.jpg", ImageAuthorName = "Norman Toth", ImageSourceId = "lCVP-lu0kxk", ImageAuthorId = "100rulez" },
                    new Portrait { Id = "candidate-lauren-portrait", ImageUrl = "media/candidate-lauren.jpg", ImageAuthorName = "Brandon Morgan", ImageSourceId = "w0Hf1hBKHdk", ImageAuthorId = "littleppl85" },
                    new Portrait { Id = "candidate-nisha-portrait", ImageUrl = "media/candidate-nisha.jpg", ImageAuthorName = "Cezanne Ali", ImageSourceId = "zv-3GbTGnzc", ImageAuthorId = "cezanne_ali" },
                    new Portrait { Id = "candidate-betthany-portrait", ImageUrl = "media/candidate-betthany.jpg", ImageAuthorName = "Brooke Cagle", ImageSourceId = "TK35M7fUWqM", ImageAuthorId = "brookecagle" }
                }
            )
        { }
    }

    public class SampleRecruitersDataCollection : Collection<Recruiter>
    {
        public SampleRecruitersDataCollection()
            : base(
                new List<Recruiter>
                {
                    new Recruiter { Id = "recruiter-freya", FirstName = "Freya", LastName = "Marzec" }
                }
            )
        { }
    }

    public class SampleCandidatesDataCollection : Collection<Candidate>
    {
        public SampleCandidatesDataCollection()
            : base(
                new List<Candidate>
                {
                    new Candidate { Id = "candidate-lev", FirstName = "Lev", LastName = "Chodosh", SkillDescription = "C#, ASP.NET, SQL" },
                    new Candidate { Id = "candidate-ilya", FirstName = "Ilya", LastName = "Lenart", SkillDescription = "JavaScript, Node.JS" },
                    new Candidate { Id = "candidate-erin", FirstName = "Erin", LastName = "Presky", SkillDescription = "Python, Django" }
                }
            )
        { }
    }

    public class SampleAcquaintancesDataCollection : Collection<Acquaintance>
    {
        public SampleAcquaintancesDataCollection()
            : base(
                new List<Acquaintance>
                {
                    new Acquaintance { SourcePersonId = "recruiter-freya", DestinationPersonId = "candidate-ilya" },
                    new Acquaintance { SourcePersonId = "recruiter-freya", DestinationPersonId = "candidate-erin" },
                    new Acquaintance { SourcePersonId = "candidate-lev", DestinationPersonId = "candidate-ilya" },
                    new Acquaintance { SourcePersonId = "candidate-lev", DestinationPersonId = "candidate-erin" },
                    new Acquaintance { SourcePersonId = "candidate-ilya", DestinationPersonId = "candidate-erin" }
                }
            )
        { }
    }
}