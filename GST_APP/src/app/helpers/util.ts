export function JSONSafeParse(jsonData: string | null | undefined) {
  try {
    if (!jsonData) {
      throw new Error('');
    }
    return JSON.parse(jsonData);
  } catch (err) {
    return null;
  }
}

export function JSONSafeStringify(object: any) {
  try {
    return JSON.stringify(object);
  } catch (err) {
    return null;
  }
}
