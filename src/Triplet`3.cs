namespace Icod {

	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public class Triplet<TFirst, TSecond, TThird> {

		#region fields
		private static readonly System.Int32 theHashCode;

		private readonly System.Int32 myHashCode;
		private readonly TFirst myFirst;
		private readonly TSecond mySecond;
		private readonly TThird myThird;
		#endregion fields


		#region .ctor
		static Triplet() {
			var q = System.Reflection.Assembly.GetExecutingAssembly().GetType();
			theHashCode = q.AssemblyQualifiedName.GetHashCode();
			unchecked {
				foreach ( var t in q.GetGenericArguments() ) {
					theHashCode += t.AssemblyQualifiedName.GetHashCode();
				}
			}
		}

		protected Triplet() : base() {
			myHashCode = theHashCode;
		}
		public Triplet( TFirst first, TSecond second, TThird third ) : this() {
			myFirst = first;
			mySecond = second;
			myThird = third;
			unchecked {
				if ( null != first ) {
					myHashCode += first.GetHashCode();
				}
				if ( null != second ) {
					myHashCode += second.GetHashCode();
				}
				if ( null != third ) {
					myHashCode += third.GetHashCode();
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
		public virtual TThird Third {
			get {
				return myThird;
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