namespace Icod.Threading { 

	/// <include file='..\..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockExitHandler"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	internal delegate void LockExitHandler();

	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
#if NET8_0_OR_GREATER
	internal delegate System.Int32 VolatileRead( ref readonly System.Int32 location );
#elif NET5_0_OR_GREATER 
	internal delegate System.Int32 VolatileRead( ref System.Int32 location );
#else
	internal delegate System.Int32 VolatileRead( ref System.Int32 address );
#endif

	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
#if NET8_0_OR_GREATER
	internal delegate void VolatileWrite( ref System.Int32 location, System.Int32 value );
#else
	internal delegate void VolatileWrite( ref System.Int32 address, System.Int32 value );
#endif
}