using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Trainee.Controllers
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class TraineeController : ApiController
    {
        List<Trainee> names = new List<Trainee> {
                new Trainee { Id=1, Name = "jim", Age=10},
                new Trainee { Id=2, Name = "john", Age=20},
                new Trainee { Id=3, Name = "jake", Age=25} };
        
        
        public List<Trainee> Post(Trainee newMem)
        {
            names.Add(newMem);
            return names;
        }
        public List<String> Get()
        {
            //Method Syntax
            return names.Select(p => p.Name).ToList();
            //Query Syntax
            //return (from q in names
            //select q.Name).ToList();
        }
        public List<Trainee> Delete(int id)
        {
            var test = names.Where(p => p.Id == id).FirstOrDefault();
            if(test!=null)
            names.Remove(test);
            return names;
        }
        public List<Trainee> Put(Trainee trainee)
        {
            //Trainee vr = names.Where(p => p.Id == trainee.Id).FirstOrDefault();
            //var index = names.IndexOf(vr);
            //names[index] = trainee;

            
            names = names.Select(x => { if(x.Id == trainee.Id) { x = trainee; } return x; }).ToList();
            //names.Add(trainee);
            return names;
        }
   
    }
}
