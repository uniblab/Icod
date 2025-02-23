namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCollection`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public interface IDataCollection<T> : IDataEnumerable<T>, IDataAddable<T>, IDataClearable<T>, IDataCopyable<T>, IDataCountable<T>, IDataExistential<T>, IDataRemoveable<T>, System.Collections.Generic.ICollection<T> where T : IDataReadable, new() { 
	}

}