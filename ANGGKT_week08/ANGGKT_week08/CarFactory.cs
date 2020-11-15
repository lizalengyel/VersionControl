using ANGGKT_week08.Abstractions;
using ANGGKT_week08.Entities;

namespace ANGGKT_week08
{
    public class CarFactory : IToyFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}