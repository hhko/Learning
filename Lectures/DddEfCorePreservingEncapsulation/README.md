# DDD and EF Core - Preserving Encapsulation

## 자료
- [DDD and EF Core: Preserving Encapsulation](https://app.pluralsight.com/library/courses/ddd-ef-core-preserving-encapsulation/table-of-contents)
- Blogs
  - [Domain-Driven Design and Entity Framework Core – two years on](https://www.thereformedprogrammer.net/domain-driven-design-and-entity-framework-core-two-years-on/)
- Youtube
  - [마이크로서비스 개발을 위한 Domain Driven Design](https://www.youtube.com/watch?v=QUMERCN3rZs)
  
## 
1. Introduction
   - 1.1 Introduction
   - 1.2 Encapsulation and Separation of Concerns
   - 1.3 Encapsulation and Separation of Concerns: Examples
   - 1.4 Sample Application Introduction
   - 1.5 Summary
1. Working with Many-to-one Relationships
   - 2.1 Introduction
   - 2.2 DbContext Encapsulation
   - 2.3 Recap: DbContext Encapsulation
   - 2.4 Getting Rid of Public Setters
   - 2.5 Recap: Getting Rid of Public Setters
   - 2.6 Types of Relationships
   - 2.7 Many-to-one Relationships: IDs vs. Navigation Properties
   - 2.8 Refactoring to Navigation Properties
   - 2.9 Recap: Refactoring to Navigation Properties
   - 2.10 Summary
1. Working with Lazy Loading
   - 3.1 Introduction
   - 3.2 Eager Loading of Relationships
   - 3.3 Lazy Loading of Relationships
   - 3.4 Refactoring to Lazy Loading
   - 3.5 Recap: Refactoring to Lazy Loading
   - 3.6 The Identity Map Pattern
   - 3.7 The Identity Map Pattern: Referential Equality
   - 3.8 Encapsulating Equality Comparison
   - 3.9 Introducing a Base Entity Class
   - 3.10 Recap: Introducing a Base Entity Class
   - 3.11 Summary
1. Mapping Backing Fields
   - 4.1 Introduction
   - 4.2 Introducing a One-to-many Relationship: Part 1
   - 4.3 Introducing a One-to-many Relationship: Part 2
   - 4.4 Recap: Introducing a One-to-many Relationship
   - 4.5 Hiding the Collection Behind a Backing Field
   - 4.6 Recap: Hiding the Collection Behind a Backing Field
   - 4.7 Introducing a Collection Invariant
   - 4.8 Recap: Introducing a Collection Invariant
   - 4.9 Deleting an Item from the Collection
   - 4.10 Recap: Deleting an Item from the Collection
   - 4.11 Shortcomings of Mapping to Backing Fields in EF Core
   - 4.12 Summary
1. Working with Disconnected Graphs of Objects
   - 5.1 Introduction
   - 5.2 New Use Case: Registering a Student
   - 5.3 Recap: Registering a Student
   - 5.4 Update and Attach Methods in DbSet
   - 5.5 Recap: Add vs. Update vs. Attach Methods in DbSet
   - 5.6 Assigning a Disconnected Entity to a Connected One
   - 5.7 Recap: Assigning a Disconnected Entity to a Connected One
   - 5.8 Summary
1. Mapping Value Objects
   - 6.1 Introduction
   - 6.2 Introducing a Value Object: Email
   - 6.3 Shortcomings of EF Core Value Conversions
   - 6.4 Introducing a Multi-property Value Object
   - 6.5 Owned Entity Types Behind the Scenes
   - 6.6 Recap: Owned Entity Types Behind the Scenes
   - 6.7 Adding a Navigation Property to an Owned Entity
   - 6.8 Summary
1. Implementing a Domain Event Dispatcher
   - 7.1 Introduction
   - 7.2 Domain Events
   - 7.3 Implementing Domain Events
   - 7.4 Recap: Implementing Domain Events
   - 7.5 Many-to-many Relationships
   - 7.6 One-to-one Relationships
   - 7.7 Resource List
   - 7.8 Course Summary
   - 7.9 Clip Watched  
