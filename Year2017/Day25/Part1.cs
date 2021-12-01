using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day25
{
  public class Part1 : IPuzzle
  {
    public class Post
    {
      public int Id { get; init; }

      public int? ParentPostId { get; init; }
      public int ThreadId { get; init; }
      public int UserId { get; init; }
      public DateTime PostDate { get; init; }
      public string Body { get; init; }
      public byte? ModerationFlag { get; init; }

      public Post AsCollapsedPost()
      {
        return new Post
        {
          Id = this.Id,
          ParentPostId = this.ParentPostId,
          ThreadId = this.ThreadId,
          UserId = this.UserId,
          Body = this.Body.Length <= 60 ? this.Body : this.Body.Substring(0, 56) + " ...",
          ModerationFlag = this.ModerationFlag,
          PostDate = this.PostDate
        };
      }

      public Post Clone()
      {
        return new Post
        {
          Id = this.Id,
          ParentPostId = this.ParentPostId,
          ThreadId = this.ThreadId,
          UserId = this.UserId,
          Body = this.Body,
          ModerationFlag = this.ModerationFlag,
          PostDate = this.PostDate
        };
      }
    }

    public class Thread
    {
      private List<Post> posts;
      private Dictionary<int, Post> postLookup;

      public int Id { get; init; }
      public int UserId { get; init; }

      public int RootPostId => this.RootPost == null ? 0 : this.RootPost.Id;

      public Post RootPost { get; init; }

      public IEnumerable<Post> Posts => this.posts;

      public IReadOnlyDictionary<int, Post> PostLookup => this.postLookup;

      public bool IsExpired => this.postLookup[this.RootPostId].PostDate.AddDays(18) < DateTime.Now;

      public Thread()
      {
      }

      public Thread(IEnumerable<Post> posts)
      {
        this.posts = posts.ToList();
        this.postLookup = this.posts.ToDictionary(p => p.Id, p => p);
      }

      public void AddPost(Post post)
      {
        this.posts.Add(post);
        this.postLookup.Add(post.Id, post);
      }
    }


    public class PostContainer
    {
      public int Indent;
      public Post Post;
      public Post LastReply;
    }


    public object Run(string input)
    {
      var threads = Enumerable.Range(1, 50).Select(t => BuildCollapsedThread(t)).ToList();

      var sw = new System.Diagnostics.Stopwatch();
      sw.Start();

      foreach (var thread in threads)
      {
        // Assumptions:
        // 1) Thread posts will be in order by ID
        // 2) Root post is not part of the Posts collection

        // Contains the posts in display order with the indent level.  Linked list makes building the order fast due to good insert speed.
        var linkedList = new LinkedList<PostContainer>();

        // Using a dictionary makes looking up the linked list nodes by post ID extremely fast.  Works great with the linked list.
        var postNodeLookup = new Dictionary<int, LinkedListNode<PostContainer>>();

        // Adding this to start is useful for minimiizing logic based on its existence.  It is removed at the end.
        var rootPostContainer = new PostContainer { Indent = 0, Post = thread.RootPost };

        linkedList.AddFirst(rootPostContainer);
        postNodeLookup.Add(thread.RootPostId, linkedList.First);

        foreach (var post in thread.Posts)
        {
          var parentPostNode = postNodeLookup[post.ParentPostId.Value];
          var postContainer = new PostContainer { Indent = parentPostNode.Value.Indent + 1, Post = post };

          // We always want to insert this post after the last reply to the parent post (so it stays in order).  This means needing to track
          // the last reply of each parent post as we insert each reply.  This adds an extra lookup but prevents needing to traverse the linked list.
          // If there are no replies to the parent post already, insert after the parent post (it is the first).  
          var lastReplyNode = parentPostNode.Value.LastReply != null ? postNodeLookup[parentPostNode.Value.LastReply.Id] : parentPostNode;

          var postNode = linkedList.AddAfter(lastReplyNode, postContainer);
          postNodeLookup.Add(post.Id, postNode);

          parentPostNode.Value.LastReply = post;
        }

        // Remove the root post now since we do not want to include it in the summary.  It's job is done.
        linkedList.RemoveFirst();

        // To get the actual last replies we want to display, create a pre-sized array and fill from the bottom, starting with the last node in the linked list.
        // Doing this manually avoids having to traverse the full linked list and only requires traversing the last 30 items, starting from the end. This also
        // prevents having to resize the array on insertion.  A list with a set capacity would probably work too but whatever.

        // Make sure we don't take more than we have.
        int size = Math.Min(postNodeLookup.Count, 30);

        var lastPosts = new PostContainer[size];
        var lastPostNode = linkedList.Last;

        for (int i = size - 1; i >= 0; i--)
        {
          lastPosts[i] = lastPostNode.Value;
          lastPostNode = lastPostNode.Previous;
        }
      }

      sw.Stop();

      return sw.ElapsedMilliseconds;
    }

    public Thread BuildCollapsedThread(int threadId)
    {
      var rng = new Random(10000);
      var posts = new Dictionary<int, Post>();
      string sampleBody = "A SelectList collection containing all departments is passed to the view for the drop-down list. The parameters passed to the SelectList constructor specify the value field name, the text field name, and the selected item.";

      var rootPost = new Post
      {
        Id = 1,
        UserId = 1,
        ParentPostId = null,
        PostDate = DateTime.Now,
        Body = sampleBody,
        ThreadId = threadId,
        ModerationFlag = 0
      };

      for (int i = 2; i <= 1000; i++)
      {
        var post = new Post
        {
          Id = i,
          UserId = 1,
          ParentPostId = 1,
          PostDate = DateTime.Now,
          Body = sampleBody,
          ThreadId = threadId,
          ModerationFlag = 0
        };

        posts.Add(post.Id, post);
      }

      // random replies
      for (int i = 1001; i <= 5000; i++)
      {
        var newPost = new Post
        {
          Id = i,
          UserId = 1,
          ParentPostId = rng.Next(2, i - 1),
          PostDate = DateTime.Now,
          Body = sampleBody,
          ThreadId = threadId,
          ModerationFlag = 0
        };

        posts.Add(newPost.Id, newPost);
      }

      var thread = new Thread(posts.Values.OrderBy(p => p.Id).ToList())
      {
        Id = threadId,
        RootPost = rootPost,
        UserId = 1
      };

      return thread;
    }
  }
}
