﻿//
// UriExtensionTests.cs
//
// Author: Jeffrey Stedfast <jestedfa@microsoft.com>
//
// Copyright (c) 2013-2025 .NET Foundation and Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using MailKit;

namespace UnitTests {
	[TestFixture]
	public class UriExtensionTests
	{
		[Test]
		public void TestNoQuery ()
		{
			var uri = new Uri ("imap://imap.gmail.com/");
			var query = uri.ParsedQuery ();

			Assert.That (query, Is.Empty, "Unexpected number of queries.");
		}

		[Test]
		public void TestSimpleQuery ()
		{
			var uri = new Uri ("imap://imap.gmail.com/?starttls=false");
			var query = uri.ParsedQuery ();

			Assert.That (query, Has.Count.EqualTo (1), "Unexpected number of queries.");
			Assert.That (query["starttls"], Is.EqualTo ("false"), "Unexpected value for 'starttls'.");
		}

		[Test]
		public void TestCompoundQuery ()
		{
			var uri = new Uri ("imap://imap.gmail.com/?starttls=false&compress=false");
			var query = uri.ParsedQuery ();

			Assert.That (query, Has.Count.EqualTo (2), "Unexpected number of queries.");
			Assert.That (query["starttls"], Is.EqualTo ("false"), "Unexpected value for 'starttls'.");
			Assert.That (query["compress"], Is.EqualTo ("false"), "Unexpected value for 'compress'.");
		}

		[Test]
		public void TestQueryWithoutValue ()
		{
			var uri = new Uri ("imap://imap.gmail.com/?starttls=false&compress");
			var query = uri.ParsedQuery ();

			Assert.That (query, Has.Count.EqualTo (2), "Unexpected number of queries.");
			Assert.That (query["starttls"], Is.EqualTo ("false"), "Unexpected value for 'starttls'.");
			Assert.That (query["compress"], Is.EqualTo (string.Empty), "Unexpected value for 'compress'.");
		}
	}
}
