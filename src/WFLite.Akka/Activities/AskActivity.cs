using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Akka.Bases;
using WFLite.Interfaces;

namespace WFLite.Akka.Activities
{
    public class AskActivity : AsyncActivity
    {
        private IActorRef _actor;

        public IVariable Message
        {
            private get;
            set;
        }

        public IVariable Timeout
        {
            private get;
            set;
        }

        public IVariable Result
        {
            private get;
            set;
        }

        public AskActivity(IActorRef actor)
        {
            _actor = actor;
        }

        public AskActivity(IActorRef actor, IVariable message, IVariable timeout = null, IVariable result = null)
        {
            _actor = actor;
            Message = message;
            Timeout = timeout;
            Result = result;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var result = default(object);
            var message = Message.GetValue();

            if (Timeout == null)
            {
                result = await _actor.Ask(message, cancellationToken);
            }
            else
            {
                result = await _actor.Ask(message, Timeout.GetValue<TimeSpan>(), cancellationToken);
            }

            if (Result != null)
            {
                Result.SetValue(result);
            }

            return true;
        }
    }
}
