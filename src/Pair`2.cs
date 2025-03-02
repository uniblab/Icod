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

	/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Pair`2"]/member[@name=""]/*'/>
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
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Pair`2"]/member[@name="#sctor"]/*'/>
		static Pair() {
			var q = System.Reflection.Assembly.GetExecutingAssembly().GetType();
			theHashCode = q.AssemblyQualifiedName.GetHashCode();
			unchecked {
				foreach ( var t in q.GetGenericArguments() ) {
					theHashCode += t.AssemblyQualifiedName.GetHashCode();
				}
			}
		}


		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Pair`2"]/member[@name="#ctor"]/*'/>
		protected Pair() : base() {
			myHashCode = theHashCode;
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Pair`2"]/member[@name="#ctor(`0,`1)"]/*'/>
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
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Pair`2"]/member[@name="First"]/*'/>
		public virtual TFirst First {
			get {
				return myFirst;
			}
		}
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Pair`2"]/member[@name="Second"]/*'/>
		public virtual TSecond Second {
			get {
				return mySecond;
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.Pair`2"]/member[@name="GetHashCode"]/*'/>
		public override System.Int32 GetHashCode() {
			return myHashCode;
		}
		#endregion methods

	}

}