namespace lesson4_createApi
{
    public class DataContextFake:IDataContext
    {
        public List<Event> EventLists { get; set; }
        public DataContextFake()
        {
            EventLists = new List<Event>() {  new Event { Id=0, Title= "blabla",Start=new  DateTime(2023,11,2)}
        , new Event { Id=1, Title= "blabla2",Start=new  DateTime(2023,11,3)},
            new Event { Id=2, Title= "blabla3",Start=new  DateTime(2023,11,4)}};
        }
    }
}
