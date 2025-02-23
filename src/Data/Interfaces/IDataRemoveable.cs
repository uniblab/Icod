namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataRemoveable`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public interface IDataRemoveable<T> { 

		/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataRemoveable`1"]/member[@name="Remove(`0)"]/*'/>
		System.Boolean Remove( T item );

	}

}