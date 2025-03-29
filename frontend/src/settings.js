export const LengthUnit = {
  Centimeters: 0,
  Inches: 1,
  toString(unit) {
    return unit === LengthUnit.Centimeters ? 'cm' : 'in'
  },
  toStringFull(unit) {
    return unit === LengthUnit.Centimeters ? 'centimeter' : 'inch'
  }
}

export const WeightUnit = {
  Kilograms: 0,
  Pounds: 1,
  toString(unit) {
    return unit === WeightUnit.Kilograms? 'kg' : 'lb'
  },
  toStringFull(unit) {
    return unit === WeightUnit.Kilograms? 'kilogram' : 'pound'
  }
}

const Settings = {
  lengthUnit: LengthUnit.Centimeters,
  weightUnit: WeightUnit.Kilograms,
  height: 0,
  startingWeight: 0,
  startingDate: new Date().toISOString().split('T')[0],
  goalWeight: 0,
  goalPercentage: 0,
}

export default Settings

