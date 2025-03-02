namespace Icod.Threading { 

	///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public static class Interlocked {

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Add(System.Int64@,System.Int64)"]/*'/>
		public static System.Int64 Add( ref System.Int64 value, System.Int64 with ) { 
			System.Int64 j = value;
			System.Int64 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i + with, j );
			} while ( i != j );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Add(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 Add( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i + with, j );
			} while ( i != j );

			return j;
		}
		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Increment(System.Int32@)"]/*'/>
		public static System.Int32 Increment( ref System.Int32 value ) { 
			return System.Threading.Interlocked.Increment( ref value );
		}
		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Increase(System.Int32@)"]/*'/>
		public static System.Int32 Increase( ref System.Int32 value ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, ( i << 1 ) | 1, j );
			} while ( i != j );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Subtract(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 Subtract( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i - with, j );
			} while ( i != j );

			return j;
		}
		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Decrement(System.Int32@)"]/*'/>
		public static System.Int32 Decrement( ref System.Int32 value ) { 
			return System.Threading.Interlocked.Decrement( ref value );
		}
		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Decrease(System.Int32@)"]/*'/>
		public static System.Int32 Decrease( ref System.Int32 value ) { 
			return Icod.Threading.Interlocked.ShiftRight( ref value, 1 );
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Multiply(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 Multiply( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i * with, j );
			} while ( i != j );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Divide(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 Divide( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i / with, j );
			} while ( i != j );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="And(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 And( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i & with, j );
			} while ( i != j );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Or(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 Or( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i | with, j );
			} while ( i != j );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="Xor(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 Xor( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i ^ with, j );
			} while ( i != j );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="ShiftRight(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 ShiftRight( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i >> with, j );
			} while ( ( i != j ) && ( 0 != j ) );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="ShiftLeft(System.Int32@,System.Int32)"]/*'/>
		public static System.Int32 ShiftLeft( ref System.Int32 value, System.Int32 with ) { 
			System.Int32 j = value;
			System.Int32 i;

			do { 
				i = j;
				j = System.Threading.Interlocked.CompareExchange( ref value, i << with, j );
			} while ( ( i != j ) && ( 0 != j ) );

			return j;
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="ExchangeCompare(System.Int32@,System.Int32,System.Int32)"]/*'/>
		public static System.Boolean ExchangeCompare( ref System.Int32 target, System.Int32 condition, System.Int32 value ) { 
			return ( condition == System.Threading.Interlocked.CompareExchange( ref target, value, condition ) );
		}

		///<include file='../../doc/Icod.Threading.xml' path='types/type[@name="Icod.Threading.Interlocked"]/member[@name="ExchangeCompare`3(`0@,`1,`2)"]/*'/>
		public static System.Boolean ExchangeCompare<O>( ref O target, O condition, O value ) where O : class { 
			return System.Object.ReferenceEquals( condition, System.Threading.Interlocked.CompareExchange( ref target, value, condition ) );
		}

	}

}