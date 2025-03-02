# Icod
Icod is a ultility library.  

## Icod
The top-level namespace contains some helpful data structures for serialization, 
such as `Pair` and `Triplet`; 
AsyncResult wrappers to support APM; 
and a helpful structure for disposing a chain of disposable object instances.

## Icod.Threading
This namespace exposes some very efficient user-mode and kernel-mode locks in a 
uniform interface permitting one to work with locks generically.  This is 
especially useful because this means locking types could be declared in a config 
file instead of literally typed in the source code.  Such locks could then be 
changed on the fly, in respose to load demands and usage patterns.

## Icod.Attributes
This namespace publishes a few helpful attribute clases concerning accountability 
and licensing.  The `ReportBugsTo` and `AuthorAttribute` help brand a class with 
the party responsible for it.  There are also two license attributes, 
`LgplLicenseAttribute` and `GplLicenseAttribute`.  These further mark the licensing 
associated with a particular class by directly referencing the appropriate license 
directly in the binary.  These should be used in conjuction with the standard 
comment-boilerplate in the source code.

## Copyright and Licensing
Icod.Argh is a command-line arguments handler and processor.
Copyright (C) 2025 Timothy J. Bruce

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 3 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
USA
