import { AppProvider } from "./providers/app";
import { ThemeProvider } from "./providers/theme";
import { AppRoutes } from "./routes";

const App = () => {
  return (
    <AppProvider>
      <ThemeProvider defaultTheme="light" storage-key="spawn-ui-theme">
      <AppRoutes />
      </ThemeProvider>
    </AppProvider>
  );
};
export default App;

