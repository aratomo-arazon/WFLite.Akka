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
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Akka.Activities
{
    public class AskActivity : AsyncActivity
    {
        public IOutVariable<ICanTell> ActorRef
        {
            private get;
            set;
        }

        public IOutVariable Request
        {
            private get;
            set;
        }

        public IInVariable Response
        {
            private get;
            set;
        }

        public IOutVariable<TimeSpan> Timeout
        {
            private get;
            set;
        }

        public AskActivity()
        {
        }

        public AskActivity(IOutVariable<ICanTell> actorRef, IOutVariable request, IInVariable response = null, IOutVariable<TimeSpan> timeout = null)
        {
            ActorRef = actorRef;
            Request = request;
            Response = response;
            Timeout = timeout;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var actorRef = ActorRef.GetValue();
            var request = Request.GetValueAsObject();
            var response = default(object);

            if (Timeout == null)
            {
                response = await actorRef.Ask(request, cancellationToken);
            }
            else
            {
                response = await actorRef.Ask(request, Timeout.GetValue(), cancellationToken);
            }

            if (Response != null)
            {
                Response.SetValue(response);
            }

            return true;
        }
    }

    public class AskActivity<TRequest, TResponse> : AsyncActivity
    {
        public IOutVariable<ICanTell> ActorRef
        {
            private get;
            set;
        }

        public IOutVariable<TRequest> Request
        {
            private get;
            set;
        }

        public IInVariable<TResponse> Response
        {
            private get;
            set;
        }

        public IOutVariable<TimeSpan> Timeout
        {
            private get;
            set;
        }

        public AskActivity()
        {
        }

        public AskActivity(IOutVariable<ICanTell> actorRef, IOutVariable<TRequest> request, IInVariable<TResponse> response = null, IOutVariable<TimeSpan> timeout = null)
        {
            ActorRef = actorRef;
            Request = request;
            Response = response;
            Timeout = timeout;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var actorRef = ActorRef.GetValue();
            var request = Request.GetValue();
            var response = default(TResponse);

            if (Timeout == null)
            {
                response = await actorRef.Ask<TResponse>(request, cancellationToken);
            }
            else
            {
                response = await actorRef.Ask<TResponse>(request, Timeout.GetValue(), cancellationToken);
            }

            if (Response != null)
            {
                Response.SetValue(response);
            }

            return true;
        }
    }
}
