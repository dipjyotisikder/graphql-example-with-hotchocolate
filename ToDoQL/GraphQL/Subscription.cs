using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace ToDoQL.GraphQL
{
    /// <summary>
    /// A class that represents graphQL subscription mechanism.
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Adds subscription for Item creation.
        /// </summary>
        /// <param name="uniqueId">Unique ID.</param>
        /// <param name="topicEventReceiver">Event receiver.</param>
        /// <returns>Notification object.</returns>
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<AddItemResponse>> OnItemCreated([Service] ITopicEventReceiver topicEventReceiver)
        {
            var itemCreationTopic = $"{"ItemCreated"}";
            return await topicEventReceiver.SubscribeAsync<AddItemResponse>(itemCreationTopic);
        }
    }
}
