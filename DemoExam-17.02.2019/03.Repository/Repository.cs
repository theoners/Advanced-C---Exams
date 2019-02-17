using System.Collections.Generic;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> data;
        private int id;
        public Repository()
        {
            this.data = new Dictionary<int, Person>();
            this.id = 0;
        }

        public int Count => data.Count;
        
        

        public void Add(Person person)
        {
           this.data.Add(id, person);
            id++;
        }

        public Person Get(int id)
        {
            return this.data[id];
        }

        public bool Update(int id, Person person)
        {
            if (this.data.ContainsKey(id))
            {
                data[id] = person;
                
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.data.ContainsKey(id))
            {
                data.Remove(id);
               
                return true ;
            }

            return false;
        }
    }
}
