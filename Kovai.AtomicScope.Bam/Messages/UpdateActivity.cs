using System;
using Kovai.AtomicScope.Bam.Common;

namespace Kovai.AtomicScope.Bam.Messages
{
	public class UpdateActivityRequest
	{
		/// <summary>
		/// Gets or sets the business process.
		/// </summary>
		/// <value>
		/// The business process.
		/// </value>
		
		public string BusinessProcess { get; set; }
		/// <summary>
		/// Gets or sets the business transaction.
		/// </summary>
		/// <value>
		/// The business transaction.
		/// </value>
		
		public string BusinessTransaction { get; set; }
		/// <summary>
		/// Gets or sets the current stage.
		/// </summary>
		/// <value>
		/// The current stage.
		/// </value>
		
		public string CurrentStage { get; set; }
		/// <summary>
		/// Gets or sets the message body.
		/// </summary>
		/// <value>
		/// The message body.
		/// </value>
		
		public string MessageBody { get; set; }
		/// <summary>
		/// Gets or sets the message header.
		/// </summary>
		/// <value>
		/// The message header.
		/// </value>
		
		public string MessageHeader { get; set; }
		/// <summary>
		/// Gets or sets the main activity identifier.
		/// </summary>
		/// <value>
		/// The main activity identifier.
		/// </value>
		
		public Guid MainActivityId { get; set; }
		/// <summary>
		/// Gets or sets the stage activity identifier.
		/// </summary>
		/// <value>
		/// The stage activity identifier.
		/// </value>
		
		public Guid StageActivityId { get; set; }
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		
		public StageStatus Status { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this instance is archive enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is archive enabled; otherwise, <c>false</c>.
		/// </value>
		
		public bool IsArchiveEnabled { get; set; }
		/// <summary>
		/// Gets or sets the ResourceId.
		/// </summary>
		/// <value>
		/// The previous stage.
		/// </value>

		public string ResourceId { get; set; }
		
		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <exception cref="InvalidMessageBody"></exception>
		/// <exception cref="InvalidMessageHeader"></exception>
		/// <exception cref="InvalidMainActivityId"></exception>
		/// <exception cref="InvalidStageActivityId"></exception>
		/// <exception cref="InvalidBusinessTransactionException">
		/// </exception>
		/// <exception cref="InvalidStageNameException"></exception>
		public void Validate()
		{
			if(string.IsNullOrEmpty(MessageBody))
				throw new InvalidMessageBody();
			if(string.IsNullOrEmpty(MessageHeader))
				throw new InvalidMessageHeader();
			if(MainActivityId == default)
				throw new InvalidMainActivityId();
			if(StageActivityId == default)
				throw new InvalidStageActivityId();
			if(string.IsNullOrEmpty(BusinessTransaction))
				throw new InvalidBusinessTransactionException();
			if(string.IsNullOrEmpty(BusinessProcess))
				throw new InvalidBusinessTransactionException();
			if(string.IsNullOrEmpty(CurrentStage))
				throw new InvalidStageNameException();
		}
	}
}
