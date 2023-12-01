# Class 9 Homework

## Using markdown, complete the next Quiz


### 1. What is software architecture, and why is it important in the development process?

Software architecture is the main structure of a software system. It encompasses the organization of its components and their relationships. It guides the design and evolution of the system.
It serves as a model of how the system will be built. 
It will help to maintain high quality code, although this is generally costly.
If the internal quality of the code is neglected, waste will quickly accumulate and slow down the development of new features.
In this case, it will allow the team to add features with less effort, time and cost.


### 2. Explain the difference between architecture and design in software development.

Architecture is concerned with the overall structure and organization, focuses on high-level structural decisions, determining the system’s components, their relationships and how they interact; while design deals with the specifics of how each part is built. Design concentrates on the implementation details of individual components.


### 3. Describe the role of software architecture throughout the software development lifecycle.

The role of software architecture throughout the software development is crucial, first we need to analyze requirements, the architects needs to understand and define system requirements.
Then, the architects guide the development team in creating a system that conforms to the established architecture, making critical descisions about structure and technology.
Testing: The architecture informs testing strategies, ensuring that the system meets functional and non-functional requirements.
Lastly, Maintenance and evolution: As the system evolves, the architects can adapt the architecture to accommodate new features, technologies or changing requirements, ensuring that the system remains robust and scalable.


### 4. Discuss how Clean Architecture can be applied in a practical scenario, such as a web application or mobile app.

Components of Clean Architecture:

- Entities:
Definition: Entities encapsulate the core business logic and are independent of external frameworks.
Practical Application: In a web application, entities could represent fundamental business objects like User, Product, or Order. These entities should contain the essential properties and behaviors of these objects.

- Use Cases:
Definition: Use Cases contain application-specific business rules and orchestrate the flow of data between entities.
Practical Application: For a web application, use cases might involve handling user interactions, processing requests, and ensuring that business rules are enforced. They encapsulate the application's core functionality.

- Interface Adapters:
Definition: Interface Adapters convert data between the use cases and the external world (frameworks or tools).
Practical Application: In a web application, this layer is responsible for translating data between the application's business logic and the user interface. It adapts the data to and from the format expected by the use cases.

- Frameworks and Drivers:
Definition: This outermost layer contains frameworks, tools, and delivery mechanisms. It deals with the implementation details specific to the chosen platform (web, mobile, etc.).
Practical Application: For a web application, this layer includes the web framework (e.g., Django, Flask), database frameworks, external APIs, and any other tools specific to web development.


### 5. Provide advantages and potential challenges of adopting Clean Architecture in a team-based development environment.

Advantages:

- Maintainability: Clean Architecture promotes a separation of concerns, making it easier to maintain and update specific parts of the system without affecting others.
- Testability: The architecture facilitates unit testing of core business logic without relying on external frameworks, leading to more effective and isolated testing.
- Flexibility: Teams can adapt and evolve the system's components independently, fostering flexibility in development and reducing dependencies.

Challenges:

- Learning Curve: Team members may require time to understand and adapt to the Clean Architecture principles, potentially slowing down initial development.
- Over-Engineering: There's a risk of over-complicating the architecture, especially in smaller projects where a simpler approach might be more appropriate.
- Coordination: Teams need to communicate effectively to ensure consistency in applying Clean Architecture principles across the entire system.
