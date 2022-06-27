Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports CS.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace CS
	' Token: 0x0200000B RID: 11
	Friend NotInheritable Module Module1
		' Token: 0x06000033 RID: 51 RVA: 0x00002B6C File Offset: 0x00000D6C
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Public Sub Main()
			Dim flag As Boolean = Not MySettingsProperty.Settings.authed
			If flag Then
				ProjectData.EndApp()
			End If
			Dim hostName As String = Dns.GetHostName()
			Dim arg As String = Dns.GetHostByName(hostName).AddressList.GetValue(0).ToString()
			Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://pastebin.com/qHcaJzKW"), HttpWebRequest)
			Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
			Dim streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
			Dim text As String = streamReader.ReadToEnd()
			Dim flag2 As Boolean = text.Contains(String.Format("{0}", arg))
			If flag2 Then
				Module1.settings = File.ReadAllText("settings.txt")
				Module1.MsgB = Regex.Match(Module1.settings, "MassageBox:(.*?)]").Groups(1).Value
				Module1.WriteMsg = Regex.Match(Module1.settings, "WriteMessage:(.*?)]").Groups(1).Value
				Module1.bio = Regex.Match(Module1.settings, "Bio:(.*?)]").Groups(1).Value
				Console.Title = "[ UHeO ]"
				Console.SetWindowSize(75, 10)
				ServicePointManager.UseNagleAlgorithm = False
				ServicePointManager.Expect100Continue = False
				ServicePointManager.CheckCertificateRevocationList = False
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
				Module1.LoadFile("Usernames", "List.txt", Module1.Usernames)
				Module1.LoadFile("Sessions", "Sessions.txt", Module1.Sessions)
				Module1.LoadFile("Proxies", "Proxies.txt", Module1.Proxies)
				Module1.Shuffle(Of String)(Module1.Proxies)
				Console.Clear()
				Module1.Threads = 1000
				Dim text2 As String = Module1.Input("Enter Threads : ")
				Dim flag3 As Boolean = Not String.IsNullOrEmpty(text2)
				If flag3 Then
					Module1.Threads = Integer.Parse(text2)
				End If
				Module1.sv = ServicePointManager.FindServicePoint(New Uri("https://i.instagram.com"))
				Module1.sv.UseNagleAlgorithm = False
				Module1.sv.Expect100Continue = False
				Module1.sv.ConnectionLimit = Integer.MaxValue
				Module1.sv.SetTcpKeepAlive(False, 0, 0)
				Dim thread As Thread = AddressOf Module1.Threading
				thread.Start()
				Console.Clear()
				Dim array As Task() = New Task(0) {}
				Dim num As Integer = 0
				Dim [function] As Func(Of Task)
				If Module1._Closure$__.$I19-0 IsNot Nothing Then
					[function] = Module1._Closure$__.$I19-0
				Else
					Dim func As Func(Of Task) = Function()
						Module1.Title()
						Dim result As Task
						Return result
					End Function
					[function] = func
					Module1._Closure$__.$I19-0 = func
				End If
				array(num) = Task.Run([function])
				Task.WaitAny(array)
			Else
				File.WriteAllText("Your IP.txt", String.Format("{0}", arg))
				Interaction.MsgBox(String.Format("Your IP : {0}{1}Is Not Activated..{2}Contact The Seller Please.", arg, vbCrLf, vbCrLf), MsgBoxStyle.Exclamation, "Coded By @h6le")
				ProjectData.EndApp()
			End If
		End Sub

		' Token: 0x06000034 RID: 52 RVA: 0x00002E1C File Offset: 0x0000101C
		Public Sub Threading()
			Dim flag As Boolean = Not Module1.app
			If flag Then
				Dim threads As Integer = Module1.Threads
				For i As Integer = 0 To threads
					Dim start As ThreadStart
					If Module1._Closure$__.$I20-0 IsNot Nothing Then
						start = Module1._Closure$__.$I20-0
					Else
						Dim threadStart As ThreadStart = Sub()
							Module1.JustLoop()
						End Sub
						start = threadStart
						Module1._Closure$__.$I20-0 = threadStart
					End If
					Dim thread As Thread = New Thread(start)
					thread.Start()
					thread.IsBackground = False
					Thread.Sleep(10)
				Next
			End If
		End Sub

		' Token: 0x06000035 RID: 53 RVA: 0x00002E8C File Offset: 0x0000108C
		Public Sub JustLoop()
			' The following expression was wrapped in a checked-statement
			While Not Module1.app
				Try
					Module1.ProxiesManager += 1
					Dim flag As Boolean = Module1.ProxiesManager >= Module1.Proxies.Count
					If flag Then
						Module1.ProxiesManager = 0
					End If
					Module1.Hcheck(Module1.Proxies(Module1.ProxiesManager))
					Module1.Hcheck2(Module1.Proxies(Module1.ProxiesManager))
				Catch ex As Exception
				End Try
				Thread.Sleep(10)
			End While
		End Sub

		' Token: 0x06000036 RID: 54 RVA: 0x00002F2C File Offset: 0x0000112C
		Public Sub Hcheck(proxy As String)
			' The following expression was wrapped in a checked-statement
			While Not Module1.app
				Try
					Module1.UsersManager += 1
					Dim flag As Boolean = Module1.UsersManager >= Module1.Usernames.Count
					If flag Then
						Module1.UsersManager = 0
					End If
					Dim text As String = Module1.Usernames(Module1.UsersManager)
					Dim text2 As String = Module1.Usernames(Module1.rn.[Next](0, Module1.Usernames.Count - 1))
					Dim text3 As String = Module1.Usernames(Module1.rn.[Next](0, Module1.Usernames.Count - 1))
					Dim httpWebRequest As HttpWebRequest = WebRequest.CreateHttp("https://i.instagram.com/accounts/username_suggestions/")
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(String.Format("name={0}+{1}&email={2}@gmail.com", text2, text3, text))
					httpWebRequest.Method = "POST"
					httpWebRequest.ServicePoint.UseNagleAlgorithm = False
					httpWebRequest.ServicePoint.ConnectionLimit = Module1.Threads
					httpWebRequest.Proxy = New WebProxy(proxy)
					httpWebRequest.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 13_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/80.0.95 Mobile/15E148 Safari/604.1"
					httpWebRequest.Headers.Add("X-CSRFTOKEN: CSRFT-" + Module1.rn.[Next](0, 99999).ToString())
					httpWebRequest.Headers.Add("Cookie: ig_did=" + Guid.NewGuid().ToString().ToUpper() + "; ds_user_id=" + Module1.rn.[Next](0, 99999).ToString())
					httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
					httpWebRequest.ContentLength = CLng(bytes.Length)
					Dim requestStream As Stream = httpWebRequest.GetRequestStream()
					requestStream.Write(bytes, 0, bytes.Length)
					requestStream.Dispose()
					requestStream.Close()
					Dim httpWebResponse As HttpWebResponse
					Try
						httpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Catch ex As WebException
						httpWebResponse = CType(ex.Response, HttpWebResponse)
					End Try
					Dim streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text4 As String = streamReader.ReadToEnd().ToString()
					Dim flag2 As Boolean = text4.Contains("[""" + text + """")
					If flag2 Then
						Console.ForegroundColor = ConsoleColor.White
						Console.Write("[")
						Console.ForegroundColor = ConsoleColor.Red
						Console.Write("x")
						Console.ForegroundColor = ConsoleColor.White
						Console.Write("] ")
						Console.ForegroundColor = ConsoleColor.Blue
						Console.Write("Trying To Claim ")
						Console.ForegroundColor = ConsoleColor.Red
						Console.Write(String.Format("@{0}", text) + vbCrLf)
						Dim start As ParameterizedThreadStart
						If Module1._Closure$__.$IR22-1 IsNot Nothing Then
							start = Module1._Closure$__.$IR22-1
						Else
							Dim parameterizedThreadStart As ParameterizedThreadStart = Sub(a0 As Object)
								Module1.Swap(Conversions.ToString(a0))
							End Sub
							start = parameterizedThreadStart
							Module1._Closure$__.$IR22-1 = parameterizedThreadStart
						End If
						Dim thread As Thread = New Thread(start)
						thread.Start(text)
					Else
						Dim flag3 As Boolean = text4.Contains("[""" + text2 + """")
						If flag3 Then
							Console.ForegroundColor = ConsoleColor.White
							Console.Write("[")
							Console.ForegroundColor = ConsoleColor.Red
							Console.Write("x")
							Console.ForegroundColor = ConsoleColor.White
							Console.Write("] ")
							Console.ForegroundColor = ConsoleColor.Blue
							Console.Write("Trying To Claim ")
							Console.ForegroundColor = ConsoleColor.Red
							Console.Write(String.Format("@{0}", text2) + vbCrLf)
							Dim start2 As ParameterizedThreadStart
							If Module1._Closure$__.$IR22-2 IsNot Nothing Then
								start2 = Module1._Closure$__.$IR22-2
							Else
								Dim parameterizedThreadStart2 As ParameterizedThreadStart = Sub(a0 As Object)
									Module1.Swap(Conversions.ToString(a0))
								End Sub
								start2 = parameterizedThreadStart2
								Module1._Closure$__.$IR22-2 = parameterizedThreadStart2
							End If
							Dim thread2 As Thread = New Thread(start2)
							thread2.Start(text2)
						Else
							Dim flag4 As Boolean = text4.Contains("[""" + text3 + """")
							If flag4 Then
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("[")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("x")
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("] ")
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write("Trying To Claim ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write(String.Format("@{0}", text3) + vbCrLf)
								Dim start3 As ParameterizedThreadStart
								If Module1._Closure$__.$IR22-3 IsNot Nothing Then
									start3 = Module1._Closure$__.$IR22-3
								Else
									Dim parameterizedThreadStart3 As ParameterizedThreadStart = Sub(a0 As Object)
										Module1.Swap(Conversions.ToString(a0))
									End Sub
									start3 = parameterizedThreadStart3
									Module1._Closure$__.$IR22-3 = parameterizedThreadStart3
								End If
								Dim thread3 As Thread = New Thread(start3)
								thread3.Start(text3)
							Else
								Dim flag5 As Boolean = text4.Contains("suggestions")
								If flag5 Then
									Module1.Counter += 1
									Console.Title = String.Format("Ok[{0}] - Ba[{1}] - R/s[{2}] - Sid[{3}] - @'s[{4}]", New Object() { Module1.Counter, Module1.Failed, Module1.RS, Module1.Sessions.Count, Module1.Usernames.Count })
									Continue While
								End If
								Dim flag6 As Boolean = text4.Contains("fail")
								If flag6 Then
									Module1.Failed += 1
									Console.Title = String.Format("Ok[{0}] - Ba[{1}] - R/s[{2}] - Sid[{3}] - @'s[{4}]", New Object() { Module1.Counter, Module1.Failed, Module1.RS, Module1.Sessions.Count, Module1.Usernames.Count })
								End If
							End If
						End If
					End If
					streamReader.Dispose()
					streamReader.Close()
				Catch ex2 As Exception
				End Try
				Thread.Sleep(10)
				Exit While
			End While
		End Sub

		' Token: 0x06000037 RID: 55 RVA: 0x00003504 File Offset: 0x00001704
		Public Sub Hcheck2(proxy As String)
			' The following expression was wrapped in a checked-statement
			While Not Module1.app
				Try
					Module1.UsersManager += 1
					Dim flag As Boolean = Module1.UsersManager >= Module1.Usernames.Count
					If flag Then
						Module1.UsersManager = 0
					End If
					Dim text As String = Module1.Usernames(Module1.UsersManager)
					Dim text2 As String = Module1.Usernames(Module1.rn.[Next](0, Module1.Usernames.Count - 1))
					Dim text3 As String = Module1.Usernames(Module1.rn.[Next](0, Module1.Usernames.Count - 1))
					Dim httpWebRequest As HttpWebRequest = WebRequest.CreateHttp("https://i.instagram.com/api/v1/accounts/username_suggestions/")
					Dim bytes As Byte() = Encoding.UTF8.GetBytes(String.Format("name={0}+{1}&email={2}@gmail.com", text2, text3, text))
					httpWebRequest.Method = "POST"
					httpWebRequest.ServicePoint.UseNagleAlgorithm = False
					httpWebRequest.ServicePoint.ConnectionLimit = Module1.Threads
					httpWebRequest.Proxy = New WebProxy(proxy)
					httpWebRequest.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 13_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/80.0.95 Mobile/15E148 Safari/604.1"
					httpWebRequest.Headers.Add("X-CSRFTOKEN: CSRFT-" + Module1.rn.[Next](0, 99999).ToString())
					httpWebRequest.Headers.Add("Cookie: ig_did=" + Guid.NewGuid().ToString().ToUpper() + "; ds_user_id=" + Module1.rn.[Next](0, 99999).ToString())
					httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
					httpWebRequest.ContentLength = CLng(bytes.Length)
					Dim requestStream As Stream = httpWebRequest.GetRequestStream()
					requestStream.Write(bytes, 0, bytes.Length)
					requestStream.Dispose()
					requestStream.Close()
					Dim httpWebResponse As HttpWebResponse
					Try
						httpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Catch ex As WebException
						httpWebResponse = CType(ex.Response, HttpWebResponse)
					End Try
					Dim streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text4 As String = streamReader.ReadToEnd().ToString()
					Dim flag2 As Boolean = text4.Contains("[""" + text + """")
					If flag2 Then
						Console.ForegroundColor = ConsoleColor.White
						Console.Write("[")
						Console.ForegroundColor = ConsoleColor.Red
						Console.Write("x")
						Console.ForegroundColor = ConsoleColor.White
						Console.Write("] ")
						Console.ForegroundColor = ConsoleColor.Blue
						Console.Write("Trying To Claim ")
						Console.ForegroundColor = ConsoleColor.Red
						Console.Write(String.Format("@{0}", text) + vbCrLf)
						Dim start As ParameterizedThreadStart
						If Module1._Closure$__.$IR23-4 IsNot Nothing Then
							start = Module1._Closure$__.$IR23-4
						Else
							Dim parameterizedThreadStart As ParameterizedThreadStart = Sub(a0 As Object)
								Module1.Swap(Conversions.ToString(a0))
							End Sub
							start = parameterizedThreadStart
							Module1._Closure$__.$IR23-4 = parameterizedThreadStart
						End If
						Dim thread As Thread = New Thread(start)
						thread.Start(text)
					Else
						Dim flag3 As Boolean = text4.Contains("[""" + text2 + """")
						If flag3 Then
							Console.ForegroundColor = ConsoleColor.White
							Console.Write("[")
							Console.ForegroundColor = ConsoleColor.Red
							Console.Write("x")
							Console.ForegroundColor = ConsoleColor.White
							Console.Write("] ")
							Console.ForegroundColor = ConsoleColor.Blue
							Console.Write("Trying To Claim ")
							Console.ForegroundColor = ConsoleColor.Red
							Console.Write(String.Format("@{0}", text2) + vbCrLf)
							Dim start2 As ParameterizedThreadStart
							If Module1._Closure$__.$IR23-5 IsNot Nothing Then
								start2 = Module1._Closure$__.$IR23-5
							Else
								Dim parameterizedThreadStart2 As ParameterizedThreadStart = Sub(a0 As Object)
									Module1.Swap(Conversions.ToString(a0))
								End Sub
								start2 = parameterizedThreadStart2
								Module1._Closure$__.$IR23-5 = parameterizedThreadStart2
							End If
							Dim thread2 As Thread = New Thread(start2)
							thread2.Start(text2)
						Else
							Dim flag4 As Boolean = text4.Contains("[""" + text3 + """")
							If flag4 Then
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("[")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("x")
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("] ")
								Console.ForegroundColor = ConsoleColor.Blue
								Console.Write("Trying To Claim ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write(String.Format("@{0}", text3) + vbCrLf)
								Dim start3 As ParameterizedThreadStart
								If Module1._Closure$__.$IR23-6 IsNot Nothing Then
									start3 = Module1._Closure$__.$IR23-6
								Else
									Dim parameterizedThreadStart3 As ParameterizedThreadStart = Sub(a0 As Object)
										Module1.Swap(Conversions.ToString(a0))
									End Sub
									start3 = parameterizedThreadStart3
									Module1._Closure$__.$IR23-6 = parameterizedThreadStart3
								End If
								Dim thread3 As Thread = New Thread(start3)
								thread3.Start(text3)
							Else
								Dim flag5 As Boolean = text4.Contains("suggestions")
								If flag5 Then
									Module1.Counter += 1
									Console.Title = String.Format("Ok[{0}] - Ba[{1}] - R/s[{2}] - Sid[{3}] - @'s[{4}]", New Object() { Module1.Counter, Module1.Failed, Module1.RS, Module1.Sessions.Count, Module1.Usernames.Count })
									Continue While
								End If
								Dim flag6 As Boolean = text4.Contains("fail")
								If flag6 Then
									Module1.Failed += 1
									Console.Title = String.Format("Ok[{0}] - Ba[{1}] - R/s[{2}] - Sid[{3}] - @'s[{4}]", New Object() { Module1.Counter, Module1.Failed, Module1.RS, Module1.Sessions.Count, Module1.Usernames.Count })
								End If
							End If
						End If
					End If
					streamReader.Dispose()
					streamReader.Close()
				Catch ex2 As Exception
				End Try
				Thread.Sleep(10)
				Exit While
			End While
		End Sub

		' Token: 0x06000038 RID: 56 RVA: 0x00003ADC File Offset: 0x00001CDC
		Public Sub Swap(user As String)
			Try
				' The following expression was wrapped in a checked-expression
				Dim text As String = Module1.Sessions(Module1.rn.[Next](0, Module1.Sessions.Count - 1))
				Dim bytes As Byte() = New UTF8Encoding().GetBytes(String.Format("username={0}", user))
				Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://i.instagram.com/api/v1/accounts/set_username/"), HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.Proxy = Nothing
				httpWebRequest.Headers.Add("Cookie", String.Format("sessionid={0};", text))
				httpWebRequest.UserAgent = "Instagram 152.0.0.1.60 Android (28/9; 380dpi; 1080x2147; OnePlus; HWEVA; OnePlus6T; qcom; en_US; 146536611)"
				httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
				httpWebRequest.ContentLength = CLng(bytes.Length)
				Dim requestStream As Stream = httpWebRequest.GetRequestStream()
				requestStream.Write(bytes, 0, bytes.Length)
				requestStream.Dispose()
				requestStream.Close()
				Dim httpWebResponse As HttpWebResponse
				Try
					httpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Catch ex As WebException
					httpWebResponse = CType(ex.Response, HttpWebResponse)
				End Try
				If httpWebResponse IsNot Nothing Then
					Dim streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text2 As String = streamReader.ReadToEnd().ToString()
					If text2.Contains("""status"":""ok""") Or text2.Contains("""status"": ""ok""") Or text2.Contains("full_name") Then
						If Not Module1.claims.ToString().Contains(user) Then
							Dim value As String = Regex.Match(text2, """email"":""(.*?)"",").Groups(1).Value
							Module1.claims.AppendLine(user)
							Console.ForegroundColor = ConsoleColor.White
							Console.Write("[")
							Console.ForegroundColor = ConsoleColor.Green
							Console.Write("$")
							Console.ForegroundColor = ConsoleColor.White
							Console.Write("] ")
							Console.ForegroundColor = ConsoleColor.Green
							Console.Write(Module1.WriteMsg)
							Console.ForegroundColor = ConsoleColor.Red
							Console.Write(" @" + user)
							Console.ForegroundColor = ConsoleColor.Green
							Console.Write(" Attempts: ")
							Console.ForegroundColor = ConsoleColor.Red
							Console.Write(Module1.Counter.ToString() + vbCrLf)
							File.WriteAllText("@" + user + " Info.txt", String.Concat(New String() { "User: @", user, vbCrLf & "Email: ", value, vbCrLf & "SessionID: ", text, vbCrLf & "Successfully" }))
							If Operators.CompareString(Module1.Sessions.Count.ToString(), "1", False) = 0 Then
								Module1.app = True
								Module1.Usernames.Remove(user)
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("[")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("x")
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("] ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("Checker Stopped .. All Sessions Claimed" & vbCrLf)
							ElseIf Operators.CompareString(Module1.Usernames.Count.ToString(), "1", False) = 0 Then
								Module1.app = True
								Module1.Sessions.Remove(text)
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("[")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("x")
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("] ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("Checker Stopped .. All Usernames Claimed" & vbCrLf)
							Else
								Module1.Sessions.Remove(text)
								Module1.Usernames.Remove(user)
							End If
							Module1.send_claim(user)
							Module1.SBio(user, value, text)
							Interaction.MsgBox(String.Concat(New String() { Module1.MsgB + " @", user, vbCrLf & "Attempts: ", Module1.Counter.ToString(), vbCrLf & "UHoE" }), MsgBoxStyle.OkOnly, "UHoE")
						End If
					Else
						If text2.Contains("wait") OrElse text2.Contains("generic") OrElse text2.Contains("rate_limit_error") Then
							Module1.SwapP(user)
						ElseIf text2.Contains("challenge_required") OrElse text2.Contains("consent_required") OrElse text2.Contains("login_required") Then
							If Operators.CompareString(Module1.Sessions.Count.ToString(), "1", False) = 0 Then
								Module1.app = True
								Console.ForegroundColor = ConsoleColor.Red
								Console.WriteLine("Checker Stopped .. Sessions Burned")
							Else
								Module1.Sessions.Remove(text)
								Module1.Swap(user)
								Module1.SwapP(user)
							End If
						End If
						Module1.SwapP(user)
					End If
					streamReader.Dispose()
					streamReader.Close()
				End If
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x06000039 RID: 57 RVA: 0x00003F7C File Offset: 0x0000217C
		Public Sub SwapP(user As String)
			Try
				Dim text As String
				Dim bytes As Byte()
				Dim httpWebRequest As HttpWebRequest
				Dim address As String = Module1.Proxies(Module1.rn.[Next](0, Module1.Proxies.Count - 1))
				text = Module1.Sessions(Module1.rn.[Next](0, Module1.Sessions.Count - 1))
				bytes = New UTF8Encoding().GetBytes(String.Format("username={0}", user))
				httpWebRequest = CType(WebRequest.Create("https://i.instagram.com/api/v1/accounts/set_username/"), HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.Proxy = New WebProxy(address)
				httpWebRequest.Headers.Add("Cookie", String.Format("sessionid={0};", text))
				httpWebRequest.UserAgent = "Instagram 152.0.0.1.60 Android (28/9; 380dpi; 1080x2147; OnePlus; HWEVA; OnePlus6T; qcom; en_US; 146536611)"
				httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
				httpWebRequest.ContentLength = CLng(bytes.Length)
				Dim requestStream As Stream = httpWebRequest.GetRequestStream()
				requestStream.Write(bytes, 0, bytes.Length)
				requestStream.Dispose()
				requestStream.Close()
				Dim httpWebResponse As HttpWebResponse
				Try
					httpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Catch ex As WebException
					httpWebResponse = CType(ex.Response, HttpWebResponse)
				End Try
				If httpWebResponse IsNot Nothing Then
					Dim streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text2 As String = streamReader.ReadToEnd().ToString()
					If text2.Contains("""status"":""ok""") Or text2.Contains("""status"": ""ok""") Or text2.Contains("full_name") Then
						If Not Module1.claims.ToString().Contains(user) Then
							Dim value As String = Regex.Match(text2, """email"":""(.*?)"",").Groups(1).Value
							Module1.claims.AppendLine(user)
							Console.ForegroundColor = ConsoleColor.White
							Console.Write("[")
							Console.ForegroundColor = ConsoleColor.Green
							Console.Write("$")
							Console.ForegroundColor = ConsoleColor.White
							Console.Write("] ")
							Console.ForegroundColor = ConsoleColor.Green
							Console.Write(Module1.WriteMsg)
							Console.ForegroundColor = ConsoleColor.Red
							Console.Write(" @" + user)
							Console.ForegroundColor = ConsoleColor.Green
							Console.Write(" Attempts: ")
							Console.ForegroundColor = ConsoleColor.Red
							Console.Write(Module1.Counter.ToString() + vbCrLf)
							File.WriteAllText("@" + user + " Info.txt", String.Concat(New String() { "User: @", user, vbCrLf & "Email: ", value, vbCrLf & "SessionID: ", text, vbCrLf & "pSuccessfully" }))
							If Operators.CompareString(Module1.Sessions.Count.ToString(), "1", False) = 0 Then
								Module1.app = True
								Module1.Usernames.Remove(user)
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("[")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("x")
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("] ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("Checker Stopped .. All Sessions Claimed" & vbCrLf)
							ElseIf Operators.CompareString(Module1.Usernames.Count.ToString(), "1", False) = 0 Then
								Module1.app = True
								Module1.Sessions.Remove(text)
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("[")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("x")
								Console.ForegroundColor = ConsoleColor.White
								Console.Write("] ")
								Console.ForegroundColor = ConsoleColor.Red
								Console.Write("Checker Stopped .. All Usernames Claimed" & vbCrLf)
							Else
								Module1.Sessions.Remove(text)
								Module1.Usernames.Remove(user)
							End If
							Module1.send_claim(user)
							Module1.SBio(user, value, text)
							Interaction.MsgBox(String.Concat(New String() { Module1.MsgB + " @", user, vbCrLf & "Attempts: ", Module1.Counter.ToString(), vbCrLf & "UHoE" }), MsgBoxStyle.OkOnly, "UHoE")
						End If
					ElseIf text2.Contains("challenge_required") OrElse text2.Contains("consent_required") OrElse text2.Contains("login_required") Then
						If Operators.CompareString(Module1.Sessions.Count.ToString(), "1", False) = 0 Then
							Module1.app = True
							Console.ForegroundColor = ConsoleColor.Red
							Console.WriteLine("Checker Stopped .. Sessions Burned")
						Else
							Module1.Sessions.Remove(text)
						End If
					End If
					streamReader.Dispose()
					streamReader.Close()
				End If
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x0600003A RID: 58 RVA: 0x00004400 File Offset: 0x00002600
		Public Sub SBio(user As String, email As String, sessionid As String)
			Try
				ServicePointManager.CheckCertificateRevocationList = False
				ServicePointManager.DefaultConnectionLimit = 300
				ServicePointManager.UseNagleAlgorithm = False
				ServicePointManager.Expect100Continue = False
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
				Dim bytes As Byte() = New UTF8Encoding().GetBytes(String.Concat(New String() { "gender=1&_csrftoken=missing&_uuid=", Module1.uuid, "&external_url=&username=", user, "&email=", email, "&phone_number=&biography=", Module1.bio, "&first_name=#U" }))
				Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/"), HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.ServicePoint.UseNagleAlgorithm = False
				httpWebRequest.ServicePoint.ConnectionLimit = 300
				httpWebRequest.Proxy = Nothing
				httpWebRequest.UserAgent = "Instagram 152.0.0.1.60 Android (28/9; 380dpi; 1080x2147; OnePlus; HWEVA; OnePlus6T; qcom; en_US; 146536611)"
				httpWebRequest.Headers.Add("Accept-Language: en-US")
				httpWebRequest.Headers.Add("cookie", "sessionid=" + sessionid)
				httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
				httpWebRequest.ContentLength = CLng(bytes.Length)
				Dim requestStream As Stream = httpWebRequest.GetRequestStream()
				requestStream.Write(bytes, 0, bytes.Length)
				requestStream.Dispose()
				requestStream.Close()
				Dim streamReader As StreamReader = New StreamReader(CType(httpWebRequest.GetResponse(), HttpWebResponse).GetResponseStream())
				streamReader.ReadToEnd()
				streamReader.Dispose()
				streamReader.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600003B RID: 59 RVA: 0x00004578 File Offset: 0x00002778
		Public Sub send_claim(user As String)
			Try
				Dim utf8Encoding As UTF8Encoding = New UTF8Encoding()
				Dim s As String = String.Concat(New String() { "{""content"":"""",""embeds"": [{""title"": """",""color"":15732480,""footer"": {""text"": """",""icon_url"": """"},""fields"": [{""name"": ""Claimed @" + user + """,""value"": ""Attempts: ", Module1.Counter.ToString(), "\nGG", """,""inline"": false}],""thumbnail"": {""url"": """"},""description"": """"}]}" })
				Dim bytes As Byte() = utf8Encoding.GetBytes(s)
				Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://discord.com/api/webhooks/908441965971009566/DJnug9-fVhmZRmWa7LB6firUnNnNIfWVWsB1lUdkwmqSKuAwQ2sC8C1kw5p1LwlJNO9c"), HttpWebRequest)
				httpWebRequest.Method = "POST"
				httpWebRequest.Proxy = Nothing
				httpWebRequest.ContentType = "application/json"
				httpWebRequest.ContentLength = CLng(bytes.Length)
				Dim requestStream As Stream = httpWebRequest.GetRequestStream()
				requestStream.Write(bytes, 0, bytes.Length)
				requestStream.Dispose()
				requestStream.Close()
				Dim streamReader As StreamReader = New StreamReader(CType(httpWebRequest.GetResponse(), HttpWebResponse).GetResponseStream())
				streamReader.ReadToEnd()
				streamReader.Dispose()
				streamReader.Close()
			Catch ex As WebException
			End Try
		End Sub

		' Token: 0x0600003C RID: 60 RVA: 0x0000465C File Offset: 0x0000285C
		Public Sub Title()
			While Not Module1.app
				Dim counter As Integer = Module1.Counter
				Thread.Sleep(1000)
				Module1.RS = Module1.Counter - counter
				Console.Title = String.Format("Ok[{0}] - Ba[{1}] - R/s[{2}] - Sid[{3}] - @'s[{4}]", New Object() { Module1.Counter, Module1.Failed, Module1.RS, Module1.Sessions.Count, Module1.Usernames.Count })
				GC.Collect()
			End While
		End Sub

		' Token: 0x0600003D RID: 61 RVA: 0x00004704 File Offset: 0x00002904
		Public Function RandomString(length As Integer) As String
			Dim source As IEnumerable(Of String) = Enumerable.Repeat(Of String)("abcdefghijkmnopqrstuvwxyz0123456789".ToLower(), length)
			Dim selector As Func(Of String, Char)
			If Module1._Closure$__.$I29-0 IsNot Nothing Then
				selector = Module1._Closure$__.$I29-0
			Else
				Dim func As Func(Of String, Char) = Function(c As String) c(Module1.rn.[Next](c.Length))
				selector = func
				Module1._Closure$__.$I29-0 = func
			End If
			Return New String(source.[Select](selector).ToArray())
		End Function

		' Token: 0x0600003E RID: 62 RVA: 0x0000475C File Offset: 0x0000295C
		Public Sub LoadFile(name As String, path As String, ByRef list As List(Of String))
			Try
				list = File.ReadAllLines(path).ToList()
			Catch ex As Exception
				list = File.ReadAllLines(Module1.Input(String.Format("{0} Path :", name))).ToList()
			End Try
			Dim flag As Boolean = list.Count <= 0
			If flag Then
				Module1.Fail(String.Format("{0} empty file", name))
				Thread.Sleep(2500)
				Environment.[Exit](1)
			Else
				Module1.Success(String.Format("{0} Loaded Successfully", name))
			End If
		End Sub

		' Token: 0x0600003F RID: 63 RVA: 0x00004800 File Offset: 0x00002A00
		Public Sub Print(text As String, ic As String, first As ConsoleColor, sec As ConsoleColor, Optional input As Boolean = False)
			Console.ResetColor()
			Console.ForegroundColor = first
			Console.Write("[")
			Console.ForegroundColor = sec
			Console.Write(ic)
			Console.ForegroundColor = first
			Console.Write("] ")
			Console.Write(text)
			Console.ForegroundColor = sec
			Dim flag As Boolean = Not input
			If flag Then
				Console.WriteLine()
			End If
		End Sub

		' Token: 0x06000040 RID: 64 RVA: 0x00004864 File Offset: 0x00002A64
		Public Sub Shuffle(Of T)(ByRef list As List(Of T))
			Dim i As Integer = list.Count
			While i > 1
				i -= 1
				Dim index As Integer = Module1.rn.[Next](i + 1)
				Dim value As T = list(index)
				list(index) = list(i)
				list(i) = value
			End While
		End Sub

		' Token: 0x06000041 RID: 65 RVA: 0x000048BC File Offset: 0x00002ABC
		Public Function Input(text As String) As String
			Module1.Print(text, "x", ConsoleColor.Cyan, ConsoleColor.White, True)
			Return Console.ReadLine()
		End Function

		' Token: 0x06000042 RID: 66 RVA: 0x000021B6 File Offset: 0x000003B6
		Public Sub Fail(text As String)
			Module1.Print(text, "!", ConsoleColor.Red, ConsoleColor.White, False)
		End Sub

		' Token: 0x06000043 RID: 67 RVA: 0x000021CA File Offset: 0x000003CA
		Public Sub Warn(text As String)
			Module1.Print(text, "!", ConsoleColor.Yellow, ConsoleColor.White, False)
		End Sub

		' Token: 0x06000044 RID: 68 RVA: 0x000021DE File Offset: 0x000003DE
		Public Sub Success(text As String)
			Module1.Print(text, "+", ConsoleColor.Green, ConsoleColor.White, False)
		End Sub

		' Token: 0x06000045 RID: 69 RVA: 0x000021F2 File Offset: 0x000003F2
		Public Sub DefaultPrint(text As String)
			Module1.Print(text, "+", ConsoleColor.Cyan, ConsoleColor.White, False)
		End Sub

		' Token: 0x04000014 RID: 20
		Public rn As Random = New Random()

		' Token: 0x04000015 RID: 21
		Public Usernames As List(Of String) = New List(Of String)()

		' Token: 0x04000016 RID: 22
		Public Proxies As List(Of String) = New List(Of String)()

		' Token: 0x04000017 RID: 23
		Public Sessions As List(Of String) = New List(Of String)()

		' Token: 0x04000018 RID: 24
		Public UsersManager As Integer = 0

		' Token: 0x04000019 RID: 25
		Public ProxiesManager As Integer = 0

		' Token: 0x0400001A RID: 26
		Public Counter As Integer = 0

		' Token: 0x0400001B RID: 27
		Public Failed As Integer = 0

		' Token: 0x0400001C RID: 28
		Public RS As Integer = 0

		' Token: 0x0400001D RID: 29
		Public Threads As Integer = 0

		' Token: 0x0400001E RID: 30
		Public app As Boolean = False

		' Token: 0x0400001F RID: 31
		Public uuid As String = Guid.NewGuid().ToString()

		' Token: 0x04000020 RID: 32
		Public claims As StringBuilder = New StringBuilder()

		' Token: 0x04000021 RID: 33
		Public sv As ServicePoint

		' Token: 0x04000022 RID: 34
		Public settings As String

		' Token: 0x04000023 RID: 35
		Public MsgB As String

		' Token: 0x04000024 RID: 36
		Public WriteMsg As String

		' Token: 0x04000025 RID: 37
		Public bio As String
	End Module
End Namespace
