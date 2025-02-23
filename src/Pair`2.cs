namespace Icod {

	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public class Pair<TFirst, TSecond> {

		#region fields
		private static readonly System.Int32 theHashCode;

		private readonly System.Int32 myHashCode;
		private readonly TFirst myFirst;
		private readonly TSecond mySecond;
		#endregion fields


		#region .ctor
		static Pair() {
			var q = System.Reflection.Assembly.GetExecutingAssembly().GetType();
			theHashCode = q.AssemblyQualifiedName.GetHashCode();
			unchecked {
				foreach ( var t in q.GetGenericArguments() ) {
					theHashCode += t.AssemblyQualifiedName.GetHashCode();
				}
			}
		}

		protected Pair() : base() {
			myHashCode = theHashCode;
		}
		public Pair( TFirst first, TSecond second ) : this() {
			myFirst = first;
			mySecond = second;
			unchecked {
				if ( null != first ) {
					myHashCode += first.GetHashCode();
				}
				if ( null != second ) {
					myHashCode += second.GetHashCode();
				}
			}
		}
		#endregion .ctor


		#region properties
		public virtual TFirst First {
			get {
				return myFirst;
			}
		}
		public virtual TSecond Second {
			get {
				return mySecond;
			}
		}
		#endregion properties


		#region methods
		public sealed override System.Int32 GetHashCode() {
			return myHashCode;
		}
		#endregion methods

	}

}