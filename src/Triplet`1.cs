namespace Icod {

	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public class Triplet<T> : Icod.Triplet<T, T, T> {

		public Triplet( T first, T second, T third ) : base( first, second, third ) {
		}

	}

}