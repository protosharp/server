# Ideas

## Program

Start with appSettings

## Data (storage)

mabybe use?
* System.ComponentModel.DataAnnotations


[Table("table_name")]
class TableA : ModelReadOnly, ModelWriteOnly, Model
{
	[Key]
	public int Id {get; set;}
	public string Name {get; set;}

	public LeftJoin<TableB> TableB() => 

	public OneToOne<TableB> TableB() => OneToOne<TableA, TableB>((a, b) => a.Id == b.Id);
	public OneToN<TableA, TableB> TableB() => OneToN<TableA, TableB>((a, b) => a.Id == b.Id);
	public NToN<TableA, TableAB, TableB> TableB() => NToN<TableA, TableAB, TableB>((a,m,b) => a.Id == m.IdA && b.Id == m.IdB)
}

* One to One
* One to N
* N to N

* Left Join
* Right Join

Source Generator

## Data (event)

class EntityA : EntityReadOnly, EntityWriteOnly, Entity
{
	[Key]
	public int Id {get; set;}

	// Extensions methods with concurrency approach
	protected void Append() { }
	protected void All() { }
}


## References

[Source Generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators)