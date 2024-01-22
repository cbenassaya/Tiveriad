


namespace Tiveriad.Core.Abstractions.Entities
{
    public class DocumentDescriptionBase< T>: IEntity<T> where T: IEquatable<T>
    {
        public T? Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public string ReferenceType { get; set; }
        public string Path { get; set; }
        public string Provider { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }   

}