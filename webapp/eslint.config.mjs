import path from "node:path";
import { fileURLToPath } from "node:url";
import js from "@eslint/js";
import { FlatCompat } from "@eslint/eslintrc";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const compat = new FlatCompat({
    baseDirectory: __dirname,
    recommendedConfig: js.configs.recommended,
    allConfig: js.configs.all
});

export default [{
    ignores: ["**/node_modules", "**/build/", "**/dist/", "**/tests-examples/", "**/generated/", "**/config", "**/webpack"],
}, ...compat.extends("./node_modules/gts/"), {
    rules: {
        "@typescript-eslint/no-explicit-any": "off",
        "@typescript-eslint/no-unused-vars": "off",
        "@typescript-eslint/triple-slash-reference": "off",
        "@typescript-eslint/no-floating-promises": "off",
        eqeqeq: "off",
        "node/no-extraneous-require": "off",
        "node/no-unpublished-import": "off",
        "node/no-unsupported-features/es-syntax": "off",
        "no-process-exit": "off",
        "n/no-process-exit": "off",
        "prettier/prettier": "off",
    },
}];