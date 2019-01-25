/*
 * AskActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using System;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Interfaces;

namespace WFLite.Akka.Activities
{
    public class AskActivity : AsyncActivity
    {
        public IVariable ActorRef
        {
            private get;
            set;
        }

        public IVariable Message
        {
            private get;
            set;
        }

        public IVariable Result
        {
            private get;
            set;
        }

        public IVariable Timeout
        {
            private get;
            set;
        }

        public AskActivity()
        {
        }

        public AskActivity(IVariable actorRef, IVariable message, IVariable result = null, IVariable timeout = null)
        {
            ActorRef = actorRef;
            Message = message;
            Result = result;
            Timeout = timeout;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var actorRef = ActorRef.GetValue<IActorRef>();
            var message = Message.GetValue();
            var result = default(object);

            if (Timeout == null)
            {
                result = await actorRef.Ask(message, cancellationToken);
            }
            else
            {
                result = await actorRef.Ask(message, Timeout.GetValue<TimeSpan>(), cancellationToken);
            }

            if (Result != null)
            {
                Result.SetValue(result);
            }

            return true;
        }
    }
}
