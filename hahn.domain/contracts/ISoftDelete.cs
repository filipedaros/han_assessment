namespace hahn.domain.contracts;

public interface ISoftDelete
{
    public DateTime DeletedDate { get; set; }
}