namespace davaleba_xml_ze_2.klasebi
{
    public class Order
    {
        public int Id { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int ContainerId { get; set; }
        public int CourierId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
