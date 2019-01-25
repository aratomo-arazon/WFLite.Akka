/*
 * TellActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using Akka.Actor;
using WFLite.Activities;
using WFLite.Interfaces;

namespace WFLite.Akka.Activities
{
    public class TellActivity : SyncActivity
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

        public TellActivity()
        {
        }

        public TellActivity(IVariable actorRef, IVariable message)
        {
            ActorRef = actorRef;
            Message = message;
        }

        protected sealed override bool run()
        {
            var actor = ActorRef.GetValue<IActorRef>();

            actor.Tell(Message.GetValue());

            return true;
        }
    }
}
