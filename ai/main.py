import time


def start_ai():
    """
    This function starts an AI.

    Returns:
    str: A message indicating that the AI has started
    """
    try:
        # Start the AI
        print("Starting AI...")
        time.sleep(2)  # Simulate some initialization time

        # Return a success message
        return "AI started successfully"
    except Exception as e:
        # Log any errors that occur
        print(f"Error: {e}")
        return "Failed to start AI"


# Example usage
print(start_ai())
