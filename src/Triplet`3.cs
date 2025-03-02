/*
	copyright (c) 2025 Timothy J. ``Flytrap'' Bruce of the ICOD
	written by Timothy J. ``Flytrap'' Bruce
	uniblab@hotmail.com
*/
/*
This library is free software; you can redistribute it and/or
 modify it under the terms of the GNU Lesser General Public
 License as published by the Free Software Foundation; either
 version 3 of the License, or (at your option) any later version.  

This library is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY of FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 Lesser General Public License for more details.  

You should have received a copy of the GNU Lesser General Public
 License along with this library; if not, write to the Free Software
 Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
*/

namespace Icod {

	/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Triplet`3"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public class Triplet<TFirst, TSecond, TThird> : Icod.Pair<TFirst, TSecond> {

		#region fields
		private static readonly System.Int32 theHashCode;

		private readonly System.Int32 myHashCode;
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

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Triplet`3"]/member[@name="#ctor(`0,`1,`2)"]/*'/>
		public Triplet( TFirst first, TSecond second, TThird third ) : base( first, second ) {
			myThird = third;
			unchecked {
				myHashCode = base.GetHashCode() + theHashCode;
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
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Triplet`3"]/member[@name="Third"]/*'/>
		public virtual TThird Third {
			get {
				return myThird;
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Triplet`3"]/member[@name="GetHashCode"]/*'/>
		public sealed override System.Int32 GetHashCode() {
			return myHashCode;
		}
		#endregion methods

	}

}