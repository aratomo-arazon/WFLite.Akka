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
        public IOutVariable ActorRef
        {
            private get;
            set;
        }

        public IOutVariable Message
        {
            private get;
            set;
        }

        public IOutVariable<IActorRef> Sender
        {
            private get;
            set;
        }

        public TellActivity()
        {
        }

        public TellActivity(IOutVariable actorRef, IOutVariable message, IOutVariable<IActorRef> sender)
        {
            ActorRef = actorRef;
            Message = message;
            Sender = sender;
        }

        protected sealed override bool run()
        {
            var actor = ActorRef.GetValueAsObject();

            if (actor is IActorRef)
            {
                if (Sender == null)
                {
                    (actor as IActorRef).Tell(Message.GetValueAsObject());
                }
                else
                {
                    (actor as IActorRef).Tell(Message.GetValueAsObject(), Sender.GetValue());
                }
            }
            else if (actor is ICanTell)
            {
                (actor as ICanTell).Tell(Message.GetValueAsObject(), Sender.GetValue());
            }

            return true;
        }
    }

    public class TellActivity<TMessage> : SyncActivity
    {
        public IOutVariable ActorRef
        {
            private get;
            set;
        }

        public IOutVariable<TMessage> Message
        {
            private get;
            set;
        }

        public IOutVariable<IActorRef> Sender
        {
            private get;
            set;
        }

        public TellActivity()
        {
        }

        public TellActivity(IOutVariable actorRef, IOutVariable<TMessage> message, IOutVariable<IActorRef> sender)
        {
            ActorRef = actorRef;
            Message = message;
            Sender = sender;
        }

        protected sealed override bool run()
        {
            var actor = ActorRef.GetValueAsObject();

            if (actor is IActorRef)
            {
                if (Sender == null)
                {
                    (actor as IActorRef).Tell(Message.GetValueAsObject());
                }
                else
                {
                    (actor as IActorRef).Tell(Message.GetValueAsObject(), Sender.GetValue());
                }
            }
            else if (actor is ICanTell)
            {
                (actor as ICanTell).Tell(Message.GetValueAsObject(), Sender.GetValue());
            }

            return true;
        }
    }
}
