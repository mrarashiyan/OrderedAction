
# Action Tracker for Unity

A Unity package for efficient action tracking and management. This tool allows you to organize, execute, and debug action chains with ease, ensuring smooth execution even when exceptions occur.

---

## Features

- **Seamless Action Tracking**  
  Easily register, organize, and manage multiple actions.

- **Error Resilience**  
  Exceptions are reported but won't interrupt the execution chain, keeping your operations uninterrupted.

- **Custom Inspector**  
  Visualize all registered functions for an action directly in the Unity Inspector for improved clarity and debugging.

---

## Installation

1. Clone or download this repository.
2. Add the package folder to your Unity project under the `Assets` directory.

---

## Usage

### Registering Actions

Use the `OrderedAction` class to register and organize your functions. Each action can be given an `order` and `title` for better identification.

```csharp

[SerializeField] private OrderedAction m_MyDummyAction = new OrderedAction();
[SerializeField] private OrderedAction m_MyOtherDummyAction = new OrderedAction();

private void OnEnable()
{
    m_MyOtherDummyAction.Register(ValueChecker, order:-5);
    m_MyDummyAction.Register<string>(PlayerPrefSaver);
    m_MyDummyAction.Register<string>(SayWelcome, order:10, title:"Welcome Text Writer");
}

private void OnDisable()
{
    m_MyOtherDummyAction.Unregister(PlayerPrefSaver);
    m_MyDummyAction.Unregister<string>(SayWelcome);
    m_MyDummyAction.Unregister<string>(ValueChecker);
}


```

### Invoking Actions

Invoke all registered actions in the defined order:

```csharp

private void Start()
{
    m_MyDummyAction.Invoke("Negin");
    m_MyOtherDummyAction.Invoke();
}
```

### Inspector View

The package includes a custom Inspector to display all registered actions for a given `OrderedAction`.  

**Inspector View Example**  
_See the screenshot below for how actions are displayed in the Unity Editor._  

![Inspector View](#)  

---

## Screenshots

### Example 1: Inspector View  
_Add a screenshot showing the custom Inspector view._  

![Example Inspector View](#)

---

### Example 2: Usage Sample  
_Add a screenshot of a usage example in the Unity Editor or Console._  

![Usage Example](#)

---

## Contribution

Contributions are welcome! Feel free to submit pull requests or report issues.  

---
