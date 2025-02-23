namespace Icod.Data { 

	/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCopyable`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public interface IDataCopyable<T> { 

		/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCopyable`1"]/member[@name="CopyTo(`0[],System.Int32)"]/*'/>
		void CopyTo( T[] array, System.Int32 arrayIndex );

		/// <include file='..\..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCopyable`1"]/member[@name="CopyTo(`0[])"]/*'/>
		void CopyTo( T[] array );

	}

}