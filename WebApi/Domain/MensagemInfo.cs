using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebApi.Domain
{
	[DataContract]
	public class MensagemInfo
	{
		[DataMember(IsRequired = true)]
		public string mensagem { get; set; }
	}
}
